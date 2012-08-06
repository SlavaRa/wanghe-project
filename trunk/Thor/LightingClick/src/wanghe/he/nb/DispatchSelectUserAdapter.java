package wanghe.he.nb;

import java.util.List;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.CheckBox;
import android.widget.TextView;

public class DispatchSelectUserAdapter extends BaseAdapter {
	   private Context mContext;  
	    private List<ComputerVO> mComputerList;  
	    private int mResource;  
	    private LayoutInflater mInflater;  
	    
	    public DispatchSelectUserAdapter(Context context, List<ComputerVO> computerList,  
	            int resource) {  
	        mContext = context;  
	        mComputerList = computerList;  
	        mResource = resource;
	        mInflater = LayoutInflater.from(mContext);  
	    }  
	@Override
	public int getCount() {
		// TODO Auto-generated method stub
		return mComputerList.size();
	}

	@Override
	public Object getItem(int position) {
		// TODO Auto-generated method stub
		return mComputerList.get(position);
	}

	@Override
	public long getItemId(int position) {
		// TODO Auto-generated method stub
		return position;
	}

	@Override
	public View getView(final int position, View convertView, ViewGroup parent) {
		// TODO Auto-generated method stub
		 if (convertView == null) {  
	            convertView = mInflater.inflate(mResource, parent, false);  
	        } 
		 TextView tvUserName = (TextView) convertView.findViewById(  
	                R.id.dispatch_item_select_ip);  
	        final CheckBox ckbItem = (CheckBox) convertView.findViewById(  
	                R.id.dispatch_item_select_ip_ckb);  
	        ComputerVO computer= mComputerList.get(position);  
	        tvUserName.setText(computer.ip);  
	        System.out.println(computer.ip);  
	        ckbItem.setChecked(computer.checked);  
	        ckbItem.setOnClickListener(new View.OnClickListener() { 
	            @Override  
	            public void onClick(View v) {  
	            	mComputerList.get(position).setChecked(ckbItem.isChecked());//保存checkbox状态至位置对应的列表对象Person中  
	            }  
	        });  
	        return convertView;
	}

}
