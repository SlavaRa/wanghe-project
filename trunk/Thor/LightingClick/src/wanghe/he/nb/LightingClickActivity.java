package wanghe.he.nb;

import java.net.DatagramPacket;
import java.net.InetAddress;
import java.net.MulticastSocket;
import java.util.ArrayList;
import java.util.List;

import android.R.integer;
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
	String str = "SHUTDOWN";
	private static final int MAX_DATA_PACKET_LENGTH = 1024;
	private byte[] buffer = new byte[MAX_DATA_PACKET_LENGTH];
	private static String multicastHost = "224.0.0.1";
	private DispatchSelectUserAdapter adapter;
	private List<ComputerVO> cList;
	MulticastLock multicastLock;

	private Handler handler;

	@Override
	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);

		setContentView(R.layout.main);

		allowMulticast();

		cList = new ArrayList<ComputerVO>();

		initListData(cList);

		Button btn_search = (Button) findViewById(R.id.btn_search);
		btn_search.setOnClickListener(new View.OnClickListener() {
			@Override
			public void onClick(View v) {
				try {
					
					adapter.clearItems();
					adapter.notifyDataSetChanged();
					
					InetAddress serverAddr = InetAddress.getByName(multicastHost);
					MulticastSocket msocket = new MulticastSocket(4850);
					msocket.setTimeToLive(50);
					msocket.joinGroup(serverAddr);
					msocket.setLoopbackMode(true);

					DatagramPacket dataPacket = null;
					dataPacket = new DatagramPacket(buffer,
							MAX_DATA_PACKET_LENGTH);
					String str = Utils.getLocalIPAddress();
					if (str == null) {
						str = "NO_ADDRESS";
					}
					str="IP;"+str;
					byte[] data = str.getBytes();
					dataPacket.setData(data);
					dataPacket.setLength(data.length);
					dataPacket.setPort(4850);
					dataPacket.setAddress(serverAddr);// 224.0.0.1
					msocket.send(dataPacket);
					msocket.close();
					multicastLock.release();
				} catch (Exception e) {
					e.printStackTrace();
				}
			}
		});
		
		Button btn_shutdown= (Button) findViewById(R.id.btn_close);
		btn_shutdown.setOnClickListener(new View.OnClickListener() {
			@Override
			public void onClick(View v) {
				try
				{
					List<ComputerVO> list = adapter.getCheckedItems();
					if(list.size()==0) return;
					for(int i =0;i<list.size();i++)
					{
						InetAddress serverAddr = InetAddress.getByName(multicastHost);
						MulticastSocket msocket = new MulticastSocket(4850);
						msocket.setTimeToLive(50);
						msocket.joinGroup(serverAddr);
						msocket.setLoopbackMode(true);

						DatagramPacket dataPacket = null;
						dataPacket = new DatagramPacket(buffer,
								MAX_DATA_PACKET_LENGTH);
						String str = list.get(i).ip;
						if (str == null) {
							continue;
						}
						str="SHUT_DOWN;"+str;
						byte[] data = str.getBytes();
						dataPacket.setData(data);
						dataPacket.setLength(data.length);
						dataPacket.setPort(4850);
						dataPacket.setAddress(serverAddr);// 224.0.0.1
						msocket.send(dataPacket);
						msocket.close();
						multicastLock.release();
					}
				}
				catch(Exception e)
				{
					e.printStackTrace();
				}
				
			}
		});
		
		
		handler = new Handler() {
			@Override
			public void handleMessage(Message msg) {
				if (msg.what == 0x1245) {
					String str= msg.getData().getString("msg");
					Log.v("MainActivity", str);

					adapter.addItem(str, 4861);
					adapter.notifyDataSetChanged();
				}
			}
		};

		new Thread(new TCPServerThread(handler, 4860, this)).start();
	}

	private void initListData(List<ComputerVO> personList) {
		adapter = new DispatchSelectUserAdapter(this, personList,
				R.layout.checkitem);
		getListView().setAdapter(adapter);
	}

	private ListView getListView() {
		return (ListView) findViewById(R.id.ip_list);
	}
	
	
	

	private void allowMulticast() {
		WifiManager wifiManager = (WifiManager) getSystemService(Context.WIFI_SERVICE);
		multicastLock = wifiManager.createMulticastLock("multicast.test");
		multicastLock.acquire();
	}

}