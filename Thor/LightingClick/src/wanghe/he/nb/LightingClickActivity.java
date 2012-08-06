package wanghe.he.nb;

import java.net.DatagramPacket;
import java.net.InetAddress;
import java.net.MulticastSocket;
import java.net.NetworkInterface;
import java.net.SocketException;
import java.util.ArrayList;
import java.util.Enumeration;
import java.util.List;
import java.util.concurrent.ExecutorService;

import android.app.Activity;
import android.content.Context;
import android.net.wifi.WifiManager;
import android.net.wifi.WifiManager.MulticastLock;
import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.ListView;

public class LightingClickActivity extends Activity {
    /** Called when the activity is first created. */
    String str="SHUTDOWN";
    private static final int MAX_DATA_PACKET_LENGTH=1024;
    private byte[] buffer = new byte[MAX_DATA_PACKET_LENGTH];
    private static String multicastHost="224.0.0.1"; 
    private DispatchSelectUserAdapter adapter;
    private  List<ComputerVO> cList;
    MulticastLock multicastLock; 
    
    private Handler handler;
    private TCPServerThread tcpServerThread;
    
    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        
        setContentView(R.layout.main);
        
        allowMulticast();
        
        cList=new ArrayList<ComputerVO>();
        
        ComputerVO cp1= new ComputerVO("192.168.1.101",4850);
        ComputerVO cp2 =new ComputerVO("192.168.1.102", 4850);
        
        cList.add(cp1);
        cList.add(cp2);
        
        initListData(cList);
        
        Button btn_search=(Button)findViewById(R.id.btn_search);
        btn_search.setOnClickListener( new View.OnClickListener() {
			@Override
			public void onClick(View v) {
				try {
	        		InetAddress serverAddr = InetAddress.getByName(multicastHost);
	        		MulticastSocket msocket= new MulticastSocket(4850);
	        		msocket.setTimeToLive(50);
	        		msocket.joinGroup(serverAddr);
	        		msocket.setLoopbackMode(true);
	        		
	        		DatagramPacket dataPacket = null;
	        		dataPacket = new DatagramPacket(buffer, MAX_DATA_PACKET_LENGTH);
	        		String str= getLocalIPAddress();
					if(str==null)
					{
						str="NO_ADDRESS";
					}
					byte[] data = str.getBytes();
	        		dataPacket.setData(data);
	        		dataPacket.setLength(data.length);
	        		dataPacket.setPort(4850);
	        		dataPacket.setAddress(serverAddr);//224.0.0.1
	        		msocket.send(dataPacket);
	        		msocket.close();
	        		multicastLock.release();
				} catch (Exception e) {
					e.printStackTrace();
				}
			}
		});
        
        handler=new Handler()
        {
        	@Override
        	public void handleMessage(Message msg) {
        		if(msg.what==0x1245)
        		{
        			Log.v("MainActivity", msg.getData().getString("msg"));
        		}
        	}
        };
        
        new Thread( new TCPServerThread(handler, 4860, this)).start();
    }
    
    private void initListData(List<ComputerVO> personList) {  
        		adapter = new DispatchSelectUserAdapter(this, personList,R.layout.checkitem);
        		getListView().setAdapter(adapter);  
    }
    
    private ListView getListView() {
		return (ListView)findViewById(R.id.ip_list);
	}
    
    
    

	/**
     * 获取本地IP地址
     * */
    private String getLocalIPAddress(){
        try {
         for (Enumeration<NetworkInterface> en = NetworkInterface.getNetworkInterfaces();  
          en.hasMoreElements();) { 
          NetworkInterface intf = en.nextElement(); 
          for (Enumeration<InetAddress> enumIpAddr = intf.getInetAddresses(); enumIpAddr.hasMoreElements();) { 
           InetAddress inetAddress = enumIpAddr.nextElement(); 
           if (!inetAddress.isLoopbackAddress()) {
            return inetAddress.getHostAddress().toString();
           }
          }
         }
        } catch (SocketException ex){
        } 
        return null;
        }
    
    private void allowMulticast(){      
        WifiManager wifiManager=(WifiManager)getSystemService(Context.WIFI_SERVICE);      
        multicastLock=wifiManager.createMulticastLock("multicast.test");      
        multicastLock.acquire();      
    }      

      
}