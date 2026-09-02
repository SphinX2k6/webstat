using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using CSharpScript.Launcher.DiffPatch.Update;
using CSharpScript.Launcher.Ui.HotFix;
using UnrealEngine;

// Token: 0x02002767 RID: 10087
public class ResDownLoadMeOutOfMemoryView : UiViewBase
{
	// Token: 0x06013E7A RID: 81530 RVA: 0x0058BCF3 File Offset: 0x00589EF3
	[NullableContext(1)]
	public ResDownLoadMeOutOfMemoryView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06013E7B RID: 81531 RVA: 0x0058BCFC File Offset: 0x00589EFC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 6;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnClickCancelBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickConfirmBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06013E7C RID: 81532 RVA: 0x0058BE49 File Offset: 0x0058A049
	protected override void OnBeforeShow()
	{
		this.RefreshView();
	}

	// Token: 0x06013E7D RID: 81533 RVA: 0x0058BE54 File Offset: 0x0058A054
	private void RefreshView()
	{
		long videoResSize = Singleton<VideoResUpdate>.Instance.GetVideoResSize(EVideoResSizeType.LoginPrepare);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "DownLoadText_NeedSpace", new <>z__ReadOnlySingleElementList<object>(HotFixManager.ByteConverter(videoResSize)));
		long freeSpace = Singleton<VideoResUpdate>.Instance.GetFreeSpace();
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(1), "DownLoadText_LeftSpace", new <>z__ReadOnlySingleElementList<object>("<color=#c25757>" + HotFixManager.ByteConverter(freeSpace) + "</color>"));
	}

	// Token: 0x06013E7E RID: 81534 RVA: 0x0058BEC9 File Offset: 0x0058A0C9
	private void OnClickConfirmBtn()
	{
		ModelBase<QuestResourceModel>.Instance.UserClickOutOfMemoryView(true);
	}

	// Token: 0x06013E7F RID: 81535 RVA: 0x0058BED6 File Offset: 0x0058A0D6
	private void OnClickCancelBtn()
	{
		base.CloseMe(null);
		ModelBase<QuestResourceModel>.Instance.UserClickOutOfMemoryView(false);
	}

	// Token: 0x02008B1F RID: 35615
	private enum EComponentDefine
	{
		// Token: 0x0402EE91 RID: 192145
		NeedSpaceText,
		// Token: 0x0402EE92 RID: 192146
		LeftSpaceText,
		// Token: 0x0402EE93 RID: 192147
		CancelBtn,
		// Token: 0x0402EE94 RID: 192148
		ConfirmBtn,
		// Token: 0x0402EE95 RID: 192149
		TitleText,
		// Token: 0x0402EE96 RID: 192150
		DesText
	}
}
