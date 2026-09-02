using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020022D9 RID: 8921
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class MotorcycleDiyStickerDecoItem : GridProxyAbstract<MotorcycleDiyStickerDecoItemData>
{
	// Token: 0x06010E12 RID: 69138 RVA: 0x0049F884 File Offset: 0x0049DA84
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUISprite)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
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

	// Token: 0x06010E13 RID: 69139 RVA: 0x0049F988 File Offset: 0x0049DB88
	protected override UniTask OnBeforeStartAsync()
	{
		MotorcycleDiyStickerDecoItem.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<MotorcycleDiyStickerDecoItem.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06010E14 RID: 69140 RVA: 0x0049F9CC File Offset: 0x0049DBCC
	[NullableContext(1)]
	public override void Refresh(MotorcycleDiyStickerDecoItemData data, bool isSelected, int gridIndex)
	{
		if (data == null)
		{
			return;
		}
		bool flag = this.Data == null || this.Data.ItemId != data.ItemId;
		this.Data = data;
		UUISprite sprite = base.GetSprite(1);
		UUIItem item = base.GetItem(2);
		UUITexture texture = base.GetTexture(3);
		UUIItem item2 = base.GetItem(4);
		UUIItem item3 = base.GetItem(5);
		UUIItem item4 = base.GetItem(6);
		UUIItem item5 = base.GetItem(7);
		UUIItem item6 = base.GetItem(8);
		sprite.SetUIActive(false);
		item.SetUIActive(false);
		texture.SetUIActive(false);
		item2.SetUIActive(false);
		item4.SetUIActive(false);
		item5.SetUIActive(false);
		item6.SetUIActive(false);
		bool flag2 = (data.IsSticker ? ModelBase<MotorcycleDiyModel>.Instance.GetSelectedStickerId(data.Part) : ModelBase<MotorcycleDiyModel>.Instance.GetSelectedDecorationId(data.Part)) == data.ItemId;
		if (data.ItemId <= 0)
		{
			string path = data.IsSticker ? ConfigCommonParamById.GetStringConfig("MotorEmptyStickerIcon") : ConfigCommonParamById.GetStringConfig("MotorEmptyDecorationIcon");
			bool uiactive = data.IsSticker ? ModelBase<MotorcycleDiyModel>.Instance.IsEquipDefaultSticker(data.Part) : ModelBase<MotorcycleDiyModel>.Instance.IsEquipDefaultDecoration(data.Part);
			item.SetUIActive(true);
			base.SetTextureByPath(path, texture, null, null);
			item4.SetUIActive(uiactive);
			item3.SetUIActive(false);
			this.CurrentState = null;
		}
		else
		{
			string icon;
			int qualityId;
			if (data.IsSticker)
			{
				MotorSticker? motorStickerConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorStickerConfig(data.ItemId);
				if (motorStickerConfig == null)
				{
					return;
				}
				icon = motorStickerConfig.Value.Icon;
				qualityId = motorStickerConfig.Value.QualityId;
			}
			else
			{
				MotorDecorations? motorDecorationConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorDecorationConfig(data.ItemId);
				if (motorDecorationConfig == null)
				{
					return;
				}
				icon = motorDecorationConfig.Value.Icon;
				qualityId = motorDecorationConfig.Value.QualityId;
			}
			sprite.SetUIActive(true);
			texture.SetUIActive(true);
			base.SetTextureByPath(icon, texture, null, null);
			MotorQuality? motorQualityConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorQualityConfig(qualityId);
			if (motorQualityConfig == null)
			{
				return;
			}
			this.SetSpriteByPath(motorQualityConfig.Value.Path, sprite, false, null, null);
			EOutLookState eoutLookState = data.IsSticker ? ModelBase<MotorcycleDiyModel>.Instance.GetStickerState(data.ItemId) : ModelBase<MotorcycleDiyModel>.Instance.GetDecorationState(data.ItemId);
			bool flag3 = this.CurrentState == null || this.CurrentState.Value != eoutLookState;
			this.CurrentState = new EOutLookState?(eoutLookState);
			switch (eoutLookState)
			{
			case EOutLookState.IsEquipped:
				item4.SetUIActive(true);
				break;
			case EOutLookState.IsLock:
				item6.SetUIActive(flag2);
				break;
			case EOutLookState.IsBan:
				item2.SetUIActive(true);
				break;
			}
			if (flag || flag3)
			{
				item3.SetUIActive(eoutLookState == EOutLookState.IsLock);
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
				if (eoutLookState != EOutLookState.IsEquipped && ModelBase<MotorcycleDiyModel>.Instance.CheckRedDotInViewOpenCache(data.ItemId))
				{
					ModelBase<MotorcycleDiyModel>.Instance.RemoveRedDotInViewOpenCache(data.ItemId);
					item3.SetUIActive(true);
					this.SeqPlayer.PlayOrReplaySequenceByName("Unlock", false, null);
				}
			}
		}
		EToggleState state = flag2 ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		base.GetExtendToggle(0).SetToggleState(state, false, false, false);
	}

	// Token: 0x06010E15 RID: 69141 RVA: 0x0049FD7C File Offset: 0x0049DF7C
	public override void OnSelected(bool fireEvent)
	{
		if (this.Data == null)
		{
			return;
		}
		Action<int, UUIExtendToggle, UUIItem> onClickToggleBack = this.OnClickToggleBack;
		if (onClickToggleBack == null)
		{
			return;
		}
		onClickToggleBack(this.Data.ItemId, base.GetExtendToggle(0), base.GetItem(7));
	}

	// Token: 0x06010E16 RID: 69142 RVA: 0x0049FDB0 File Offset: 0x0049DFB0
	private void OnClickItem(EToggleState toggleState)
	{
		if (this.Data == null)
		{
			return;
		}
		Action<int, UUIExtendToggle, UUIItem> onClickToggleBack = this.OnClickToggleBack;
		if (onClickToggleBack == null)
		{
			return;
		}
		onClickToggleBack(this.Data.ItemId, base.GetExtendToggle(0), base.GetItem(7));
	}

	// Token: 0x040084FA RID: 34042
	private MotorcycleDiyStickerDecoItemData Data;

	// Token: 0x040084FB RID: 34043
	private LevelSequencePlayer SeqPlayer;

	// Token: 0x040084FC RID: 34044
	private EOutLookState? CurrentState;

	// Token: 0x040084FD RID: 34045
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	public Action<int, UUIExtendToggle, UUIItem> OnClickToggleBack;

	// Token: 0x020085B5 RID: 34229
	[NullableContext(0)]
	private class EStickerDecoItemComponent
	{
		// Token: 0x0402D3C4 RID: 185284
		public const int TogItem = 0;

		// Token: 0x0402D3C5 RID: 185285
		public const int SprQuality = 1;

		// Token: 0x0402D3C6 RID: 185286
		public const int PnlNone = 2;

		// Token: 0x0402D3C7 RID: 185287
		public const int TexIcon = 3;

		// Token: 0x0402D3C8 RID: 185288
		public const int PnlBan = 4;

		// Token: 0x0402D3C9 RID: 185289
		public const int PnlLock = 5;

		// Token: 0x0402D3CA RID: 185290
		public const int PnlSelect = 6;

		// Token: 0x0402D3CB RID: 185291
		public const int NewItem = 7;

		// Token: 0x0402D3CC RID: 185292
		public const int PreviewItem = 8;
	}
}
