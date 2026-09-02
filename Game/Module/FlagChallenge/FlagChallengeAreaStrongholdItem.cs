using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.FlagChallenge
{
	// Token: 0x02005D4F RID: 23887
	[NullableContext(1)]
	[Nullable(0)]
	public class FlagChallengeAreaStrongholdItem : UiPanelBase
	{
		// Token: 0x0603C362 RID: 246626 RVA: 0x00F45968 File Offset: 0x00F43B68
		public FlagChallengeAreaStrongholdItem(FlagChallengeStrongholdData data)
		{
			this.Data = data;
		}

		// Token: 0x0603C363 RID: 246627 RVA: 0x00F459C0 File Offset: 0x00F43BC0
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(1, typeof(UUITexture)),
				new ValueTuple<int, Type>(2, typeof(UUITexture)),
				new ValueTuple<int, Type>(3, typeof(UUITexture)),
				new ValueTuple<int, Type>(4, typeof(UUITexture)),
				new ValueTuple<int, Type>(5, typeof(UUIText)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUISprite)),
				new ValueTuple<int, Type>(8, typeof(UUISprite)),
				new ValueTuple<int, Type>(9, typeof(UUITexture))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle))
			};
		}

		// Token: 0x0603C364 RID: 246628 RVA: 0x00F45AD8 File Offset: 0x00F43CD8
		protected override void OnStart()
		{
			this.SequencePlayer = new UiSequencePlayer(this.RootItem);
			this.SequencePlayer.PlaySequencePurely("Start", false, false);
			base.GetExtendToggle(0).CanExecuteChange.Bind(new Func<bool>(this.OnCanExecuteChange));
			int challengeLevelId = this.Data.StrongholdConfig.ChallengeLevelId;
			FlagChallengeLevel? levelConfig = ConfigBase<FlagChallengeConfig>.Instance.GetLevelConfig(challengeLevelId);
			EFlagChallengeStrongholdType strongholdType = this.Data.GetStrongholdType();
			bool flag = this.Data.IsUnlocked();
			UUITexture texture = base.GetTexture(2);
			UUITexture texture2 = base.GetTexture(1);
			UUITexture texture3 = base.GetTexture(3);
			UUISprite sprite = base.GetSprite(7);
			UUISprite sprite2 = base.GetSprite(8);
			UUITexture texture4 = base.GetTexture(4);
			base.GetText(5).SetText(this.Data.GetIndex().ToString(), true);
			if (flag)
			{
				EFlagChallengeUiStyleType uiStyle = (EFlagChallengeUiStyleType)levelConfig.Value.UiStyle;
				UiResourceConfig instance = ConfigBase<UiResourceConfig>.Instance;
				bool isPass = this.Data.IsPass;
				texture.SetUIActive(!isPass);
				texture3.SetUIActive(isPass);
				texture2.SetUIActive(false);
				string dynamicRes = FlagChallengeUtils.GetDynamicRes(uiStyle, "StrongholdItemIncompleteBg", (int)strongholdType);
				base.SetTextureByPath(instance.GetResourcePath(dynamicRes), texture, null, null);
				dynamicRes = FlagChallengeUtils.GetDynamicRes(uiStyle, "StrongholdItemCompleteBg", (int)strongholdType);
				base.SetTextureByPath(instance.GetResourcePath(dynamicRes), texture3, null, null);
				string baseKey = isPass ? "StrongholdItemCompleteIcon" : "StrongholdItemIncompleteIcon";
				dynamicRes = FlagChallengeUtils.GetDynamicRes(uiStyle, baseKey, (int)strongholdType);
				base.SetTextureByPath(instance.GetResourcePath(dynamicRes), texture4, null, null);
				sprite.SetUIActive(this.Data.IsPass);
				sprite2.SetUIActive(!this.Data.IsPass);
				if (this.Data.IsBossStronghold())
				{
					UUITexture texture5 = base.GetTexture(9);
					if (texture5 != null)
					{
						texture5.SetUIActive(true);
					}
					if (texture5 == null)
					{
						return;
					}
					texture5.SetColor(FColor.FromHex(this.rollTexColor[uiStyle]));
					return;
				}
			}
			else
			{
				texture.SetUIActive(false);
				texture3.SetUIActive(false);
				texture2.SetUIActive(true);
				sprite.SetUIActive(false);
				sprite2.SetUIActive(false);
				texture4.SetUIActive(false);
				if (this.Data.IsBossStronghold())
				{
					UUITexture texture6 = base.GetTexture(9);
					if (texture6 == null)
					{
						return;
					}
					texture6.SetUIActive(false);
				}
			}
		}

		// Token: 0x0603C365 RID: 246629 RVA: 0x00F45D3D File Offset: 0x00F43F3D
		protected override void OnBeforeDestroy()
		{
			UiSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer != null)
			{
				sequencePlayer.Clear();
			}
			this.SequencePlayer = null;
		}

		// Token: 0x0603C366 RID: 246630 RVA: 0x00F45D57 File Offset: 0x00F43F57
		public void SetClickCallback(Action<int> callback)
		{
			this.ClickCallback = callback;
		}

		// Token: 0x0603C367 RID: 246631 RVA: 0x00F45D60 File Offset: 0x00F43F60
		public void SetSelected(bool isSelected, bool bFireEvent = false)
		{
			EToggleState state = isSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			base.GetExtendToggle(0).SetToggleStateForce(state, bFireEvent, false, false);
			base.GetItem(6).SetUIActive(isSelected);
			this.IsSelected = isSelected;
		}

		// Token: 0x0603C368 RID: 246632 RVA: 0x00F45D99 File Offset: 0x00F43F99
		private void OnClickToggle(EToggleState state)
		{
			this.SetSelected(true, false);
			Action<int> clickCallback = this.ClickCallback;
			if (clickCallback == null)
			{
				return;
			}
			clickCallback(this.Data.Id);
		}

		// Token: 0x0603C369 RID: 246633 RVA: 0x00F45DBE File Offset: 0x00F43FBE
		private bool OnCanExecuteChange()
		{
			return !this.IsSelected;
		}

		// Token: 0x0603C36A RID: 246634 RVA: 0x00F45DC9 File Offset: 0x00F43FC9
		public bool GetIsBoss()
		{
			return this.Data.IsBossStronghold();
		}

		// Token: 0x04021D10 RID: 138512
		private readonly Dictionary<EFlagChallengeUiStyleType, string> rollTexColor = new Dictionary<EFlagChallengeUiStyleType, string>
		{
			{
				EFlagChallengeUiStyleType.Green,
				"#CCFF00"
			},
			{
				EFlagChallengeUiStyleType.Yellow,
				"#FF7200"
			},
			{
				EFlagChallengeUiStyleType.Red,
				"#FF0042"
			},
			{
				EFlagChallengeUiStyleType.Hidden,
				"#FF0042"
			}
		};

		// Token: 0x04021D11 RID: 138513
		private readonly FlagChallengeStrongholdData Data;

		// Token: 0x04021D12 RID: 138514
		[Nullable(2)]
		private Action<int> ClickCallback;

		// Token: 0x04021D13 RID: 138515
		[Nullable(2)]
		private UiSequencePlayer SequencePlayer;

		// Token: 0x04021D14 RID: 138516
		private bool IsSelected;
	}
}
