package wanghe.he.nb;

import java.io.IOException;
import java.io.InputStream;
import java.net.ServerSocket;
import java.net.Socket;

import android.content.Context;
import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.util.Log;

public class TCPServerThread implements Runnable {
	private static final String tag = "TCPServerThread";
	private Handler handler = null;

	private ServerSocket sock = null;
	private boolean running = true;
	private int port = 4860;
	private Context context = null;
	private static final int BUFF_SIZE = 1024;

	public TCPServerThread(Handler handler, int port, Context context) {
		this.handler = handler;
		this.port = port;
		this.context = context;
		try {
			Log.v(tag, "ServerSocket start at port");
		} catch (Exception e) {
		}
	}

	public void run() {
		try {
			sock = new ServerSocket(port);
			while(running)
			{
					Socket socket = sock.accept();
					InputStream inputStream = socket.getInputStream();
					byte buffer[] = new byte[BUFF_SIZE];
					int len = 0;
					len = inputStream.read(buffer);
					String strdata = new String(buffer, 0, len);
					Message msg = new Message();
					Bundle bundle = new Bundle();
					bundle.putString("msg", strdata);
					msg.what=0x1245;
					msg.setData(bundle);
					handler.sendMessage(msg);
					Log.v(tag, strdata);
			}
		} catch (IOException e) {
			e.printStackTrace();
			try {
				sock.close();
			} catch (IOException e1) {
				// TODO Auto-generated catch block
				e1.printStackTrace();
			}
			return;
		}
		return;
	}
}
