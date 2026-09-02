using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001C56 RID: 7254
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchDebugInfoItem : UiPanelBase, IGridProxy<string>
{
	// Token: 0x17001122 RID: 4386
	// (get) Token: 0x0600D3A3 RID: 54179 RVA: 0x0038695F File Offset: 0x00384B5F
	// (set) Token: 0x0600D3A4 RID: 54180 RVA: 0x00386967 File Offset: 0x00384B67
	[Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})]
	public IScrollViewDelegate<IGridProxy<string>, string> ScrollViewDelegate { [return: Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})] set; }

	// Token: 0x17001123 RID: 4387
	// (get) Token: 0x0600D3A5 RID: 54181 RVA: 0x00386970 File Offset: 0x00384B70
	// (set) Token: 0x0600D3A6 RID: 54182 RVA: 0x00386978 File Offset: 0x00384B78
	public int GridIndex { get; set; }

	// Token: 0x17001124 RID: 4388
	// (get) Token: 0x0600D3A7 RID: 54183 RVA: 0x00386981 File Offset: 0x00384B81
	// (set) Token: 0x0600D3A8 RID: 54184 RVA: 0x00386989 File Offset: 0x00384B89
	public int DisplayIndex { get; set; }

	// Token: 0x0600D3A9 RID: 54185 RVA: 0x00386994 File Offset: 0x00384B94
	protected unsafe override void OnRegisterComponent()
	{
		int num = 1;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int index = 0;
		*span[index] = new ValueTuple<int, Type>(0, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600D3AA RID: 54186 RVA: 0x003869DC File Offset: 0x00384BDC
	public void Refresh(string data, bool isSelected, int gridIndex)
	{
		base.GetText(0).SetText(data, true);
	}

	// Token: 0x0600D3AB RID: 54187 RVA: 0x003869EC File Offset: 0x00384BEC
	public UniTask RefreshAsync(string data, bool isSelected, int gridIndex)
	{
		FloroRanchDebugInfoItem.<RefreshAsync>d__15 <RefreshAsync>d__;
		<RefreshAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshAsync>d__.<>1__state = -1;
		<RefreshAsync>d__.<>t__builder.Start<FloroRanchDebugInfoItem.<RefreshAsync>d__15>(ref <RefreshAsync>d__);
		return <RefreshAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600D3AC RID: 54188 RVA: 0x00386A27 File Offset: 0x00384C27
	public void Clear()
	{
	}

	// Token: 0x0600D3AD RID: 54189 RVA: 0x00386A29 File Offset: 0x00384C29
	public void OnSelected(bool fireEvent)
	{
	}

	// Token: 0x0600D3AE RID: 54190 RVA: 0x00386A2B File Offset: 0x00384C2B
	public void OnDeselected(bool fireEvent)
	{
	}

	// Token: 0x0600D3AF RID: 54191 RVA: 0x00386A2D File Offset: 0x00384C2D
	[return: Nullable(2)]
	public object GetKey(string data, int gridIndex)
	{
		return null;
	}

	// Token: 0x02007F65 RID: 32613
	[NullableContext(0)]
	private class EComponent
	{
		// Token: 0x0402B5F8 RID: 177656
		public const int Text = 0;
	}
}
