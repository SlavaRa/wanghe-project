package wanghe.he.nb;

import java.io.Serializable;

public class ComputerVO implements Serializable {
	
	public  ComputerVO(String IP,int Port) {
		ip=IP;
		port=Port;
	}
	/**
	 * 保存 主机复选框状态
	 */
	private static final long serialVersionUID = 1L;
	
	public String ip;
	public int port;
	public Boolean checked=false;
	
	public  void  setChecked(Boolean b) {
		checked=b;
	}
}
