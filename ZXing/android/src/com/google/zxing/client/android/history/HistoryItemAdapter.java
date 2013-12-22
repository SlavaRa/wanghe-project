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

import android.content.Context;
import android.content.res.Resources;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.LinearLayout;
import android.widget.TextView;
import com.google.zxing.Result;
import com.google.zxing.client.android.R;

import java.util.ArrayList;

final class HistoryItemAdapter extends ArrayAdapter<HistoryItem>{

	private final Context activity;

	/**
	 * construct
	 * @param activity  视图
	 */
	HistoryItemAdapter(Context activity)
	{
		super(activity, R.layout.history_list_item, new ArrayList<HistoryItem>());
		this.activity = activity;
	}

	/**
	 *  给视图填充数据
	 * @param position  位置
	 * @param view      显示对象
	 * @param viewGroup 显示对象分组
	 * @return
	 */
	@Override
	public View getView(int position, View view, ViewGroup viewGroup) {
		View layout;
//      view 是否是LinearLayout类型
		if (view instanceof LinearLayout) {
			layout = view;
		} else {
			LayoutInflater factory = LayoutInflater.from(activity);
			layout = factory.inflate(R.layout.history_list_item, viewGroup, false);
		}
// 获取索引位置的数据
		//泛型
		HistoryItem item = getItem(position);
		//从HistoryItem里获取Result 结果，这个结果是ZXing内置的类型
		Result result = item.getResult();
		CharSequence title;
		CharSequence detail;
		//有结果的情况
		if (result != null)
		{
			//  标题
			title = result.getText();
			//  获取详细信息
			detail = item.getDisplayAndDetails();
		}
		else
		{
			//  无结果的情况
			//  获取资源
			Resources resources = getContext().getResources();
			//  从资源里获取字符串
			// Ctrl+"-" 可以查看内容
			title = resources.getString(R.string.history_empty);
			detail = resources.getString(R.string.history_empty_detail);
		}
		//  设置标题
		((TextView) layout.findViewById(R.id.history_title)).setText(title);
		//  设置文本
		((TextView) layout.findViewById(R.id.history_detail)).setText(detail);
		return layout;
	}
}
