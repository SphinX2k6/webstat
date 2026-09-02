using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020028D7 RID: 10455
public class RoleTagDetailView : UiViewBase
{
	// Token: 0x06014C4E RID: 85070 RVA: 0x005C1A83 File Offset: 0x005BFC83
	[NullableContext(1)]
	public RoleTagDetailView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06014C4F RID: 85071 RVA: 0x005C1A8C File Offset: 0x005BFC8C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(2, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(3, typeof(UUIItem))
		};
	}

	// Token: 0x06014C50 RID: 85072 RVA: 0x005C1AFC File Offset: 0x005BFCFC
	protected override void OnStart()
	{
		int[] array = this.OpenParam as int[];
		if (array == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Role, ELogAuthor.BB, "RoleTagDetailView无效tagList", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.CaptionItem = new PopupCaptionItem(base.GetItem(0));
		this.CaptionItem.SetCloseCallBack(new Action(this.OnCloseCallBack));
		this.RoleTagLayout = new GenericLayout<RoleTagDetailItem, int>(base.GetVerticalLayout(1), new Func<RoleTagDetailItem>(this.InitRoleTagItem), base.GetItem(3).GetOwner() as AUIBaseActor, false, true);
		this.OtherTagLayout = new GenericLayout<RoleTagDetailItem, int>(base.GetVerticalLayout(2), new Func<RoleTagDetailItem>(this.InitRoleTagItem), base.GetItem(3).GetOwner() as AUIBaseActor, false, true);
		this.RoleTagLayout.RefreshByData(new List<int>(array), null, false);
		List<int> allRoleTagList = ConfigBase<RoleConfig>.Instance.GetAllRoleTagList();
		this.OtherTagLayout.RefreshByData(allRoleTagList, null, false);
	}

	// Token: 0x06014C51 RID: 85073 RVA: 0x005C1BEC File Offset: 0x005BFDEC
	[NullableContext(1)]
	private RoleTagDetailItem InitRoleTagItem()
	{
		return new RoleTagDetailItem();
	}

	// Token: 0x06014C52 RID: 85074 RVA: 0x005C1BF3 File Offset: 0x005BFDF3
	private void OnCloseCallBack()
	{
		base.CloseMe(null);
	}

	// Token: 0x04009FF1 RID: 40945
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x04009FF2 RID: 40946
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<RoleTagDetailItem, int> RoleTagLayout;

	// Token: 0x04009FF3 RID: 40947
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<RoleTagDetailItem, int> OtherTagLayout;

	// Token: 0x02008C32 RID: 35890
	private enum EComponent
	{
		// Token: 0x0402F39D RID: 193437
		CaptionItem,
		// Token: 0x0402F39E RID: 193438
		RoleTagRoot,
		// Token: 0x0402F39F RID: 193439
		OtherTagRoot,
		// Token: 0x0402F3A0 RID: 193440
		TagItem
	}
}
