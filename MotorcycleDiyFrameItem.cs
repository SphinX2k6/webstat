using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020022D0 RID: 8912
[Nullable(new byte[]
{
	0,
	1
})]
public class MotorcycleDiyFrameItem : GridProxyAbstract<MotorcycleDiyFrameItemData>
{
	// Token: 0x06010DD9 RID: 69081 RVA: 0x0049E1A4 File Offset: 0x0049C3A4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUITexture)),
			new ValueTuple<int, Type>(3, typeof(UUITexture)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickItem))
		};
	}

	// Token: 0x06010DDA RID: 69082 RVA: 0x0049E2A8 File Offset: 0x0049C4A8
	protected override UniTask OnBeforeStartAsync()
	{
		MotorcycleDiyFrameItem.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<MotorcycleDiyFrameItem.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06010DDB RID: 69083 RVA: 0x0049E2EC File Offset: 0x0049C4EC
	[NullableContext(1)]
	public override void Refresh(MotorcycleDiyFrameItemData data, bool isSelected, int gridIndex)
	{
		bool flag = this.FrameId != data.ItemId;
		this.FrameId = data.ItemId;
		UUITexture texture = base.GetTexture(1);
		UUITexture texture2 = base.GetTexture(2);
		UUITexture texture3 = base.GetTexture(3);
		UUIItem item = base.GetItem(4);
		UUIItem item2 = base.GetItem(5);
		UUIItem item3 = base.GetItem(6);
		UUIItem item4 = base.GetItem(7);
		UUIItem item5 = base.GetItem(8);
		item.SetUIActive(false);
		item3.SetUIActive(false);
		item4.SetUIActive(false);
		item5.SetUIActive(false);
		bool flag2 = ModelBase<MotorcycleDiyModel>.Instance.GetSelectedFrameId() == data.ItemId;
		EOutLookState frameState = ModelBase<MotorcycleDiyModel>.Instance.GetFrameState(data.ItemId);
		bool flag3 = this.CurrentState == null || this.CurrentState.Value != frameState;
		this.CurrentState = new EOutLookState?(frameState);
		switch (frameState)
		{
		case EOutLookState.IsEquipped:
			item.SetUIActive(true);
			break;
		case EOutLookState.IsLock:
			item5.SetUIActive(flag2);
			break;
		case EOutLookState.IsBan:
			item4.SetUIActive(true);
			break;
		}
		if (flag || flag3)
		{
			item2.SetUIActive(frameState == EOutLookState.IsLock);
			LevelSequencePlayer seqPlayer = this.SeqPlayer;
			if (seqPlayer != null)
			{
				seqPlayer.StopCurrentSequence(false, true);
			}
			LevelSequencePlayer seqPlayer2 = this.SeqPlayer;
			if (seqPlayer2 != null)
			{
				seqPlayer2.PlayOrReplaySequenceByName("Lock", false, null);
			}
			if (frameState != EOutLookState.IsEquipped && ModelBase<MotorcycleDiyModel>.Instance.CheckRedDotInViewOpenCache(data.ItemId))
			{
				ModelBase<MotorcycleDiyModel>.Instance.RemoveRedDotInViewOpenCache(data.ItemId);
				item2.SetUIActive(true);
				this.SeqPlayer.PlayOrReplaySequenceByName("Unlock", false, null);
			}
		}
		MotorFrame? motorFrameConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorFrameConfig(data.ItemId);
		if (motorFrameConfig == null)
		{
			return;
		}
		MotorQuality? motorQualityConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorQualityConfig(motorFrameConfig.Value.QualityId);
		if (motorQualityConfig == null)
		{
			return;
		}
		base.SetTextureByPath(motorFrameConfig.Value.ModelIconPath, texture, null, null);
		base.SetTextureByPath(motorQualityConfig.Value.FramePath, texture2, null, null);
		base.SetTextureByPath(motorQualityConfig.Value.FrameShinePath, texture3, null, null);
		EToggleState state = flag2 ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		base.GetExtendToggle(0).SetToggleState(state, false, false, false);
	}

	// Token: 0x06010DDC RID: 69084 RVA: 0x0049E564 File Offset: 0x0049C764
	public override void OnSelected(bool fireEvent)
	{
		this.OnClickToggleCallBack();
	}

	// Token: 0x06010DDD RID: 69085 RVA: 0x0049E56C File Offset: 0x0049C76C
	private void OnClickItem(EToggleState toggleState)
	{
		this.OnClickToggleCallBack();
	}

	// Token: 0x06010DDE RID: 69086 RVA: 0x0049E574 File Offset: 0x0049C774
	private void OnClickToggleCallBack()
	{
		if (this.FrameId == 0)
		{
			return;
		}
		Action<int, UUIExtendToggle, UUIItem> onClickToggleBack = this.OnClickToggleBack;
		if (onClickToggleBack == null)
		{
			return;
		}
		onClickToggleBack(this.FrameId, base.GetExtendToggle(0), base.GetItem(6));
	}

	// Token: 0x040084E8 RID: 34024
	private int FrameId;

	// Token: 0x040084E9 RID: 34025
	[Nullable(2)]
	private LevelSequencePlayer SeqPlayer;

	// Token: 0x040084EA RID: 34026
	private EOutLookState? CurrentState;

	// Token: 0x040084EB RID: 34027
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	public Action<int, UUIExtendToggle, UUIItem> OnClickToggleBack;

	// Token: 0x020085AA RID: 34218
	private class EFrameItemComponent
	{
		// Token: 0x0402D38E RID: 185230
		public const int TogFrame = 0;

		// Token: 0x0402D38F RID: 185231
		public const int TexIcon = 1;

		// Token: 0x0402D390 RID: 185232
		public const int TexQuality1 = 2;

		// Token: 0x0402D391 RID: 185233
		public const int TexQuality2 = 3;

		// Token: 0x0402D392 RID: 185234
		public const int PnlSelect = 4;

		// Token: 0x0402D393 RID: 185235
		public const int Pnllock = 5;

		// Token: 0x0402D394 RID: 185236
		public const int NewItem = 6;

		// Token: 0x0402D395 RID: 185237
		public const int BanItem = 7;

		// Token: 0x0402D396 RID: 185238
		public const int PreviewItem = 8;
	}
}
