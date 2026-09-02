using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001CA3 RID: 7331
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class FriendMultipleApplyItem : GridProxyAbstract<FriendApplyData>
{
	// Token: 0x0600D700 RID: 55040 RVA: 0x00396D28 File Offset: 0x00394F28
	protected unsafe override void OnRegisterComponent()
	{
		int num = 6;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnClickAgreeBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(5, new Action(this.OnClickRefuseBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600D701 RID: 55041 RVA: 0x00396E75 File Offset: 0x00395075
	protected override void OnStart()
	{
		this.CountDownBar = base.GetSprite(3);
	}

	// Token: 0x0600D702 RID: 55042 RVA: 0x00396E84 File Offset: 0x00395084
	[NullableContext(1)]
	public override void Refresh(FriendApplyData data, bool isSelected, int gridIndex)
	{
		this.ApplyData = data;
		FriendData applyPlayerData = data.ApplyPlayerData;
		RoleInfo? roleInfo;
		string text = (ConfigBase<RoleConfig>.Instance.GetRoleConfig(applyPlayerData.PlayerHeadPhoto) != null) ? roleInfo.GetValueOrDefault().Card : null;
		if (!string.IsNullOrEmpty(text))
		{
			base.SetTextureByPath(text, base.GetTexture(1), null, null);
		}
		base.GetText(0).SetText(applyPlayerData.PlayerName, true);
		base.GetText(2).SetText(applyPlayerData.PlayerLevel.ToString(), true);
	}

	// Token: 0x0600D703 RID: 55043 RVA: 0x00396F1C File Offset: 0x0039511C
	public void UpdateCountDownProgressBar()
	{
		if (this.ApplyData == null)
		{
			return;
		}
		this.CountDownBar.SetFillAmount((float)(this.ApplyData.ApplyTimeLeftTime / (double)ModelBase<FriendModel>.Instance.ApplyCdTime));
		if (this.ApplyData.ApplyTimeLeftTime <= 0.0)
		{
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.FriendOnMultiItemAction, this.ApplyData.ApplyPlayerData.PlayerId);
		}
	}

	// Token: 0x0600D704 RID: 55044 RVA: 0x00396F8C File Offset: 0x0039518C
	private void OnClickAgreeBtn()
	{
		ControllerBase<FriendController>.Instance.RequestFriendApplyHandle(new List<int>
		{
			this.ApplyData.ApplyPlayerData.PlayerId
		}, FriendApplyOperator.Approve);
		if (this.ApplyData == null)
		{
			return;
		}
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.FriendOnMultiItemAction, this.ApplyData.ApplyPlayerData.PlayerId);
	}

	// Token: 0x0600D705 RID: 55045 RVA: 0x00396FE8 File Offset: 0x003951E8
	private void OnClickRefuseBtn()
	{
		ControllerBase<FriendController>.Instance.RequestFriendApplyHandle(new List<int>
		{
			this.ApplyData.ApplyPlayerData.PlayerId
		}, FriendApplyOperator.Reject);
		if (this.ApplyData == null)
		{
			return;
		}
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.FriendOnMultiItemAction, this.ApplyData.ApplyPlayerData.PlayerId);
	}

	// Token: 0x040065EE RID: 26094
	private FriendApplyData ApplyData;

	// Token: 0x040065EF RID: 26095
	private UUISprite CountDownBar;

	// Token: 0x02007FF8 RID: 32760
	[NullableContext(0)]
	private class EFriendMultipleApplyItem
	{
		// Token: 0x0402B8BD RID: 178365
		public const int PlayerName = 0;

		// Token: 0x0402B8BE RID: 178366
		public const int RoleHead = 1;

		// Token: 0x0402B8BF RID: 178367
		public const int Level = 2;

		// Token: 0x0402B8C0 RID: 178368
		public const int CountDownProgressBar = 3;

		// Token: 0x0402B8C1 RID: 178369
		public const int AgreeBtn = 4;

		// Token: 0x0402B8C2 RID: 178370
		public const int RefuseBtn = 5;
	}
}
