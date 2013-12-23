/*
 * Copyright 2012 ZXing authors
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

package com.google.zxing.client.android.history;

import android.app.Activity;
import android.app.AlertDialog;
import android.app.ListActivity;
import android.content.ActivityNotFoundException;
import android.content.DialogInterface;
import android.content.Intent;
import android.net.Uri;
import android.os.Bundle;
import android.os.Parcelable;
import android.util.Log;
import android.view.ContextMenu;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import com.google.zxing.client.android.CaptureActivity;
import com.google.zxing.client.android.Intents;
import com.google.zxing.client.android.R;

public final class HistoryActivity extends ListActivity {

    private static final String TAG = HistoryActivity.class.getSimpleName();
    private HistoryManager historyManager;
    private ArrayAdapter<HistoryItem> adapter;
    private CharSequence originalTitle;

    @Override
    protected void onCreate(Bundle icicle)
    {
        super.onCreate(icicle);
//      初始化历史界面管理器
        this.historyManager = new HistoryManager(this);
//      适配器
        adapter = new HistoryItemAdapter(this);
//      设置数据
        setListAdapter(adapter);
//
        View listview = getListView();
//      注册上下文菜单
        registerForContextMenu(listview);
        originalTitle = getTitle();
    }

    //    界面恢复
    @Override
    protected void onResume() {
        super.onResume();
//      重新加载历史数据
        reloadHistoryItems();
    }

    /***
     *  重新载入历史数据
     */
    private void reloadHistoryItems() {
//      获取数据
        Iterable<HistoryItem> items = historyManager.buildHistoryItems();
        //清理适配器的数据
        adapter.clear();
        //
        for (HistoryItem item : items)
        {
            adapter.add(item);
        }
//      历史（2）
//      originalTitle 就是获取多语言的历史文本
        setTitle(originalTitle + " (" + adapter.getCount() + ')');
//      如果适配器是空的
//      则扔一个null的HistoryItem进去
        if (adapter.isEmpty())
        {
            adapter.add(new HistoryItem(null, null, null));
        }
    }

    /**
     * Item点击事件
     * @param l 列表
     * @param v view    其实是render
     * @param position  位置
     * @param id        ID
     */
    @Override
    protected void onListItemClick(ListView l, View v, int position, long id)
    {
//      有数据的情况下，发个Intent去镜头界面
        if (adapter.getItem(position).getResult() != null)
        {
	        //
            Intent intent = new Intent(this, CaptureActivity.class);
            intent.putExtra(Intents.History.ITEM_NUMBER, position);
            setResult(Activity.RESULT_OK, intent);
            finish();
        }
    }


	/***
	 * 创建Menu上下文菜单
	 * @param menu  菜单
	 * @param v
	 * @param menuInfo
	 */
    @Override
    public void onCreateContextMenu(ContextMenu menu,View v,ContextMenu.ContextMenuInfo menuInfo)
    {
        int position = ((AdapterView.AdapterContextMenuInfo) menuInfo).position;
        if (position >= adapter.getCount() || adapter.getItem(position).getResult() != null)
        {
//	        这句是我加的
	        menu.setHeaderTitle("操作");
            menu.add(Menu.NONE, position, position, R.string.history_clear_one_history_text);
        } // else it's just that dummy "Empty" message
    }

	/***
	 *上下文菜单点击事件
	 * @param item
	 * @return
	 */
    @Override
    public boolean onContextItemSelected(MenuItem item)
    {
        int position = item.getItemId();
        historyManager.deleteHistoryItem(position);
        reloadHistoryItems();
        return true;
    }

	/**
	 *  创建操作菜单
	 * @param menu  菜单
	 * @return  true就是显示 false就是不显示
	 */
    @Override
    public boolean onCreateOptionsMenu(Menu menu)
    {
        if (historyManager.hasHistoryItems())
        {
            MenuInflater menuInflater = getMenuInflater();
            menuInflater.inflate(R.menu.history, menu);
        }
        return super.onCreateOptionsMenu(menu);
    }

	/**
	 * menu键
	 * 菜单项点击事件
	 * @param  item 菜单项
	 * @return
	 */
    @Override
    public boolean onOptionsItemSelected(MenuItem item)
    {
        switch (item.getItemId())
        {
//	        发送历史记录
            case R.id.menu_history_send:
                CharSequence history = historyManager.buildHistory();
//	            过来的其实是URI
                Parcelable historyFile = HistoryManager.saveHistory(history.toString());
//	            如果没有数据
                if (historyFile == null)
                {
//	                抱歉 SD卡无法访问
                    AlertDialog.Builder builder = new AlertDialog.Builder(this);
                    builder.setMessage(R.string.msg_unmount_usb);
//	                确定按钮
                    builder.setPositiveButton(R.string.button_ok, null);
                    builder.show();
                }
                else
                {
//	                如果有数据 分享掉
                    Intent intent = new Intent(Intent.ACTION_SEND, Uri.parse("mailto:"));
                    intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_WHEN_TASK_RESET);
                    String subject = getResources().getString(R.string.history_email_title);
                    intent.putExtra(Intent.EXTRA_SUBJECT, subject);
                    intent.putExtra(Intent.EXTRA_TEXT, subject);
                    intent.putExtra(Intent.EXTRA_STREAM, historyFile);
                    intent.setType("text/csv");
                    try
                    {
//	                    这还得try catch啊
                        startActivity(intent);
                    }
                    catch (ActivityNotFoundException anfe)
                    {
                        Log.w(TAG, anfe.toString());
                    }
                }
                break;
//            删除按钮
            case R.id.menu_history_clear_text:
                AlertDialog.Builder builder = new AlertDialog.Builder(this);
	            //"你肯定吗"
                builder.setMessage(R.string.msg_sure);
                builder.setCancelable(true);
                builder.setPositiveButton(R.string.button_ok, new DialogInterface.OnClickListener()
                {
                    @Override
                    public void onClick(DialogInterface dialog, int i2)
                    {
                        historyManager.clearHistory();
                        dialog.dismiss();
                        finish();
                    }
                });
                builder.setNegativeButton(R.string.button_cancel, null);
                builder.show();
                break;
            default:
                return super.onOptionsItemSelected(item);
        }
        return true;
    }

}
