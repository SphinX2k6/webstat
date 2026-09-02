using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060DF RID: 24799
	[NullableContext(1)]
	[Nullable(0)]
	public class SpecialEnergyBarRuibeika : SpecialEnergyBarBase
	{
		// Token: 0x0603EA37 RID: 256567 RVA: 0x010083F8 File Offset: 0x010065F8
		protected override void OnRegisterComponent()
		{
			Dictionary<int, Type> dictionary = new Dictionary<int, Type>();
			dictionary[9] = typeof(UUISprite);
			dictionary[10] = typeof(UUISprite);
			dictionary[11] = typeof(UUISprite);
			dictionary[12] = typeof(UUISprite);
			Dictionary<int, Type> dictionary2 = dictionary;
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>();
			for (int i = 0; i < 27; i++)
			{
				this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(i, dictionary2.GetValueOrDefault(i, typeof(UUIItem))));
			}
		}

		// Token: 0x0603EA38 RID: 256568 RVA: 0x01008490 File Offset: 0x01006690
		protected override UniTask OnBeforeStartAsync()
		{
			SpecialEnergyBarRuibeika.<OnBeforeStartAsync>d__16 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SpecialEnergyBarRuibeika.<OnBeforeStartAsync>d__16>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603EA39 RID: 256569 RVA: 0x010084D4 File Offset: 0x010066D4
		private void InitDotItems(List<SpecialEnergyBarRuibeikaDot> arr, SpecialEnergyBarRuibeika.EChildType org, SpecialEnergyBarRuibeika.EChildType parent, int mode)
		{
			UUIItem item = base.GetItem((int)org);
			UUIItem item2 = base.GetItem((int)parent);
			for (int i = 0; i < 34; i++)
			{
				AActor actor = (i == 0) ? item.GetOwner() : Singleton<LguiUtil>.Instance.DuplicateActor(item.GetOwner(), item2);
				SpecialEnergyBarRuibeikaDot specialEnergyBarRuibeikaDot = new SpecialEnergyBarRuibeikaDot(mode);
				specialEnergyBarRuibeikaDot.SkipDestroyActor = true;
				specialEnergyBarRuibeikaDot.Index = i;
				specialEnergyBarRuibeikaDot.CreateByActorAsync(actor, null, false);
				arr.Add(specialEnergyBarRuibeikaDot);
			}
		}

		// Token: 0x0603EA3A RID: 256570 RVA: 0x01008548 File Offset: 0x01006748
		protected override void AddEvents()
		{
			base.AddEvents();
			base.ListenForTagAddOrRemoveChanged(GameplayTagDefine.EGameplayTagId["角色.R2T1RebeccaMd10011.状态.手枪状态"], this.<AddEvents>g__onStateChanged|18_0(SpecialEnergyBarRuibeika.EState.StateGun));
			base.ListenForTagAddOrRemoveChanged(GameplayTagDefine.EGameplayTagId["角色.R2T1RebeccaMd10011.状态.铁胆状态"], this.<AddEvents>g__onStateChanged|18_0(SpecialEnergyBarRuibeika.EState.StateRifle));
			base.ListenForTagAddOrRemoveChanged(GameplayTagDefine.EGameplayTagId["角色.R2T1RebeccaMd10011.状态.机枪状态"], this.<AddEvents>g__onStateChanged|18_0(SpecialEnergyBarRuibeika.EState.StateUlt));
			base.ListenForTagAddOrRemoveChanged(GameplayTagDefine.EGameplayTagId["角色.R2T1RebeccaMd10011.状态.强化切枪开启中"], delegate(int tagId, bool tagExist)
			{
				this.UpdateNorDotMode(tagExist);
			});
			base.ListenForTagAddOrRemoveChanged(GameplayTagDefine.EGameplayTagId["角色.R2T1RebeccaMd10011.技能ID.大招组.连射一阶"], this.<AddEvents>g__onUltLevelChanged|18_2(1));
			base.ListenForTagAddOrRemoveChanged(GameplayTagDefine.EGameplayTagId["角色.R2T1RebeccaMd10011.技能ID.大招组.连射二阶"], this.<AddEvents>g__onUltLevelChanged|18_2(2));
			base.ListenForTagAddOrRemoveChanged(GameplayTagDefine.EGameplayTagId["角色.R2T1RebeccaMd10011.技能ID.大招组.连射三阶"], this.<AddEvents>g__onUltLevelChanged|18_2(3));
			base.ListenForTagAddOrRemoveChanged(GameplayTagDefine.EGameplayTagId["角色.R2T1RebeccaMd10011.技能ID.大招组.终结一击"], delegate(int tagId, bool tagExist)
			{
				if (tagExist)
				{
					BattleUiTweenAnimPlayer tweenAnimPlayer = this.TweenAnimPlayer;
					if (tweenAnimPlayer == null)
					{
						return;
					}
					tweenAnimPlayer.PlayTweenAnim(23);
				}
			});
			this.EnergyMaxB = this.AttributeComponent.GetCurrentValue(EAttributeType.SpecialEnergy2Max);
			this.UpdateNorDot(this.AttributeComponent.GetCurrentValue(EAttributeType.SpecialEnergy2), false);
			this.EnergyMaxC = this.AttributeComponent.GetCurrentValue(EAttributeType.SpecialEnergy3Max);
			this.UpdateUltBarPercent(this.AttributeComponent.GetCurrentValue(EAttributeType.SpecialEnergy3));
			base.ListenForAttributeChanged(EAttributeType.SpecialEnergy2, delegate(EAttributeType attrId, float newValue, float oldValue)
			{
				this.UpdateNorDot(newValue, false);
			});
			base.ListenForAttributeChanged(EAttributeType.SpecialEnergy2Max, delegate(EAttributeType attrId, float newValue, float oldValue)
			{
				this.EnergyMaxB = newValue;
			});
			base.ListenForAttributeChanged(EAttributeType.SpecialEnergy3, delegate(EAttributeType attrId, float newValue, float oldValue)
			{
				this.UpdateUltBarPercent(newValue);
			});
			base.ListenForAttributeChanged(EAttributeType.SpecialEnergy3Max, delegate(EAttributeType attrId, float newValue, float oldValue)
			{
				this.EnergyMaxC = newValue;
			});
		}

		// Token: 0x0603EA3B RID: 256571 RVA: 0x010086E4 File Offset: 0x010068E4
		protected override void OnStart()
		{
			base.OnStart();
			this.ConfigList.Add(this.Config);
			this.ConfigList.Add(ModelBase<BattleUiModel>.Instance.SpecialEnergyBarData.GetSpecialEnergyBarInfo(130801));
			this.BarTipsWidth = base.GetSprite(9).Width;
			for (int i = 14; i <= 23; i++)
			{
				base.InitTweenAnim(i);
			}
			BaseTagComponent tagComponent = this.TagComponent;
			if (((tagComponent != null) ? new bool?(tagComponent.HasTag(GameplayTagDefine.EGameplayTagId["角色.R2T1RebeccaMd10011.状态.机枪状态"])) : null).GetValueOrDefault())
			{
				this.SetState(SpecialEnergyBarRuibeika.EState.StateUlt, true);
			}
			else
			{
				BaseTagComponent tagComponent2 = this.TagComponent;
				this.SetState(((tagComponent2 != null) ? new bool?(tagComponent2.HasTag(GameplayTagDefine.EGameplayTagId["角色.R2T1RebeccaMd10011.状态.铁胆状态"])) : null).GetValueOrDefault() ? SpecialEnergyBarRuibeika.EState.StateRifle : SpecialEnergyBarRuibeika.EState.StateGun, true);
			}
			this.OnBarPercentChanged();
		}

		// Token: 0x0603EA3C RID: 256572 RVA: 0x010087DA File Offset: 0x010069DA
		protected override void OnBeforeDestroy()
		{
			this.RemoveTimer();
			base.OnBeforeDestroy();
		}

		// Token: 0x0603EA3D RID: 256573 RVA: 0x010087E8 File Offset: 0x010069E8
		private void SetState(SpecialEnergyBarRuibeika.EState state, bool force = false)
		{
			if (this.CurState == state && !force)
			{
				return;
			}
			SpecialEnergyBarRuibeika.EState curState = this.CurState;
			this.CurState = state;
			if (state == SpecialEnergyBarRuibeika.EState.StateUlt)
			{
				this.IsUltFinalDone = false;
				this.SwitchKeyItem(this.ConfigList[1]);
				SpecialEnergyBarKeyItem keyItem = this.KeyItem;
				if (keyItem != null)
				{
					keyItem.RefreshKeyEnable(false, true);
				}
				if (curState != SpecialEnergyBarRuibeika.EState.StateUlt || force)
				{
					base.PlayTweenAnim(16);
				}
				this.UpdateUltBarPercent(this.AttributeComponent.GetCurrentValue(EAttributeType.SpecialEnergy3));
				this.UpdateUltLevel(0);
				return;
			}
			this.SwitchKeyItem(this.ConfigList[0]);
			SpecialEnergyBarKeyItem keyItem2 = this.KeyItem;
			if (keyItem2 != null)
			{
				keyItem2.RefreshKeyEnable(this.GetKeyEnable(), true);
			}
			UUIItem item = base.GetItem(6);
			if (item != null)
			{
				item.SetUIActive(state == SpecialEnergyBarRuibeika.EState.StateGun);
			}
			UUIItem item2 = base.GetItem(7);
			if (item2 != null)
			{
				item2.SetUIActive(state == SpecialEnergyBarRuibeika.EState.StateRifle);
			}
			UUIItem item3 = base.GetItem(1);
			if (item3 != null)
			{
				item3.SetUIActive(!this.IsDoubleColorMode);
			}
			UUIItem item4 = base.GetItem(3);
			if (item4 != null)
			{
				item4.SetUIActive(this.IsDoubleColorMode);
			}
			if (curState == SpecialEnergyBarRuibeika.EState.StateUlt || force)
			{
				base.PlayTweenAnim(17);
			}
			base.PlayTweenAnim((state == SpecialEnergyBarRuibeika.EState.StateGun) ? 14 : 15);
			this.UpdateNorDot(this.AttributeComponent.GetCurrentValue(EAttributeType.SpecialEnergy2), true);
		}

		// Token: 0x0603EA3E RID: 256574 RVA: 0x0100892A File Offset: 0x01006B2A
		[NullableContext(2)]
		private void SwitchKeyItem(SpecialEnergyBarInfo cfg)
		{
			if (cfg != null)
			{
				this.Config = cfg;
				SpecialEnergyBarKeyItem keyItem = this.KeyItem;
				if (keyItem != null)
				{
					keyItem.SetConfig(cfg);
				}
				SpecialEnergyBarKeyItem keyItem2 = this.KeyItem;
				if (keyItem2 == null)
				{
					return;
				}
				keyItem2.SwitchToKeyInfoList(this.Config.KeyInfoList);
			}
		}

		// Token: 0x0603EA3F RID: 256575 RVA: 0x01008963 File Offset: 0x01006B63
		private void RemoveTimer()
		{
			if (this.TimerHandle != null)
			{
				TimerSystem.Instance.Remove(this.TimerHandle);
				this.TimerHandle = null;
			}
		}

		// Token: 0x0603EA40 RID: 256576 RVA: 0x01008988 File Offset: 0x01006B88
		private void UpdateNorDotMode(bool doubleColor)
		{
			this.DelayedDoubleColorMode = doubleColor;
			this.PendingDoubleColorModeSwitch = true;
			if (this.DurationAniUse == 0f)
			{
				SpecialEnergyBarRuibeikaDot specialEnergyBarRuibeikaDot = this.C2DotItems.ElementAtOrDefault(0);
				this.DurationAniUse = Math.Max((specialEnergyBarRuibeikaDot != null) ? specialEnergyBarRuibeikaDot.GetAniUseDuration() : 0.2f, 0.2f);
			}
			this.TimerHandle = TimerSystem.Instance.Delay(delegate(float _)
			{
				this.TimerHandle = null;
				if (base.IsShowOrShowing)
				{
					this.UpdateNorDotModeInner();
				}
			}, this.DurationAniUse * 1000f, null, null, true, ModelBase<CharacterModel>.Instance.InverseSelfCenteredTimeDilation);
		}

		// Token: 0x0603EA41 RID: 256577 RVA: 0x01008A14 File Offset: 0x01006C14
		private void UpdateNorDotModeInner()
		{
			this.PendingDoubleColorModeSwitch = false;
			this.IsDoubleColorMode = this.DelayedDoubleColorMode;
			this.RemoveTimer();
			UUIItem item = base.GetItem(1);
			if (item != null)
			{
				item.SetUIActive(!this.IsDoubleColorMode);
			}
			UUIItem item2 = base.GetItem(3);
			if (item2 != null)
			{
				item2.SetUIActive(this.IsDoubleColorMode);
			}
			this.UpdateNorDot(this.AttributeComponent.GetCurrentValue(EAttributeType.SpecialEnergy2), true);
		}

		// Token: 0x0603EA42 RID: 256578 RVA: 0x01008A84 File Offset: 0x01006C84
		private void UpdateNorDot(float attrValue, bool force = false)
		{
			float num = attrValue / this.EnergyMaxB;
			if (this.PendingDoubleColorModeSwitch && num * (float)this.C2DotItems.Count > 1f)
			{
				this.UpdateNorDotModeInner();
			}
			List<SpecialEnergyBarRuibeikaDot> list = this.IsDoubleColorMode ? this.C2DotItems : this.C1DotItems;
			float num2 = num * (float)list.Count;
			for (int i = 0; i < list.Count; i++)
			{
				list[i].SetVisible((float)i < num2, this.CurState == SpecialEnergyBarRuibeika.EState.StateGun, force);
			}
		}

		// Token: 0x0603EA43 RID: 256579 RVA: 0x01008B0C File Offset: 0x01006D0C
		protected override void OnBarPercentChanged()
		{
			SpecialEnergyBarSlotItem slotItem = this.SlotItem;
			if (slotItem != null)
			{
				slotItem.UpdatePercent(this.PercentMachine.GetCurPercent(), this.GetKeyEnable(), false);
			}
			if (this.CurState != SpecialEnergyBarRuibeika.EState.StateUlt)
			{
				SpecialEnergyBarKeyItem keyItem = this.KeyItem;
				if (keyItem == null)
				{
					return;
				}
				keyItem.RefreshKeyEnable(this.GetKeyEnable(), false);
			}
		}

		// Token: 0x0603EA44 RID: 256580 RVA: 0x01008B5C File Offset: 0x01006D5C
		private void UpdateUltBarPercent(float attrValue)
		{
			float num = attrValue / this.EnergyMaxC;
			UUISprite sprite = base.GetSprite(9);
			if (sprite != null)
			{
				sprite.SetFillAmount(num);
			}
			if (!this.IsUltFinalDone)
			{
				UUIItem item = base.GetItem(24);
				if (item != null)
				{
					item.SetUIActive(true);
				}
			}
			UUIItem item2 = base.GetItem(24);
			if (item2 == null)
			{
				return;
			}
			item2.SetAnchorOffsetX(this.BarTipsWidth * (num - 0.5f));
		}

		// Token: 0x0603EA45 RID: 256581 RVA: 0x01008BC4 File Offset: 0x01006DC4
		private void UpdateUltLevel(int lv)
		{
			if (this.UltLevel == lv)
			{
				return;
			}
			this.IsUltFinalDone = false;
			this.UltLevel = lv;
			if (lv == 1)
			{
				this.UltCdDoneAnim = 18;
			}
			else if (lv == 2)
			{
				base.PlayTweenAnim(19);
				this.UltCdDoneAnim = 20;
			}
			else if (lv == 3)
			{
				base.PlayTweenAnim(21);
				this.UltCdDoneAnim = 22;
			}
			UUISprite sprite = base.GetSprite(10);
			if (sprite != null)
			{
				sprite.SetUIActive(lv == 1);
			}
			UUISprite sprite2 = base.GetSprite(11);
			if (sprite2 != null)
			{
				sprite2.SetUIActive(lv == 2);
			}
			UUISprite sprite3 = base.GetSprite(12);
			if (sprite3 != null)
			{
				sprite3.SetUIActive(lv == 3);
			}
			UUIItem item = base.GetItem(25);
			if (item != null)
			{
				item.SetUIActive(lv != 3);
			}
			UUIItem item2 = base.GetItem(26);
			if (item2 != null)
			{
				item2.SetUIActive(false);
			}
			if (lv > 0)
			{
				this.UltCdMachine.Init(0f, new float?((float)1000));
				this.UltCdMachine.SetTargetPercent(1f);
				this.UltCdBar = base.GetSprite(10 + lv - 1);
				UUISprite ultCdBar = this.UltCdBar;
				if (ultCdBar != null)
				{
					ultCdBar.SetFillAmount(0f);
				}
				SpecialEnergyBarKeyItem keyItem = this.KeyItem;
				if (keyItem == null)
				{
					return;
				}
				keyItem.RefreshKeyEnable(false, true);
			}
		}

		// Token: 0x0603EA46 RID: 256582 RVA: 0x01008D00 File Offset: 0x01006F00
		public override void Tick(float delta)
		{
			base.Tick(delta);
			if (this.UltCdMachine.Update(delta))
			{
				UUISprite ultCdBar = this.UltCdBar;
				if (ultCdBar != null)
				{
					ultCdBar.SetFillAmount(this.UltCdMachine.GetCurPercent());
				}
				if (this.UltCdMachine.GetCurPercent() >= 1f)
				{
					if (this.CurState == SpecialEnergyBarRuibeika.EState.StateUlt && this.UltLevel <= 2)
					{
						SpecialEnergyBarKeyItem keyItem = this.KeyItem;
						if (keyItem != null)
						{
							keyItem.RefreshKeyEnable(true, true);
						}
					}
					UUIItem item = base.GetItem(26);
					if (item != null)
					{
						item.SetUIActive(true);
					}
					if (this.UltLevel == 3)
					{
						this.IsUltFinalDone = true;
					}
					base.PlayTweenAnim(this.UltCdDoneAnim);
				}
			}
		}

		// Token: 0x0603EA49 RID: 256585 RVA: 0x01008E10 File Offset: 0x01007010
		[CompilerGenerated]
		private BaseTagComponent.TTagSwitchedCallback <AddEvents>g__onStateChanged|18_0(SpecialEnergyBarRuibeika.EState state)
		{
			return delegate(int tagId, bool tagExist)
			{
				if (tagExist)
				{
					this.SetState(state, false);
				}
			};
		}

		// Token: 0x0603EA4B RID: 256587 RVA: 0x01008E39 File Offset: 0x01007039
		[CompilerGenerated]
		private BaseTagComponent.TTagSwitchedCallback <AddEvents>g__onUltLevelChanged|18_2(int lv)
		{
			return delegate(int tagId, bool tagExist)
			{
				if (tagExist)
				{
					this.UpdateUltLevel(lv);
				}
			};
		}

		// Token: 0x04023210 RID: 143888
		private const int BTN_ULTCONFIG = 130801;

		// Token: 0x04023211 RID: 143889
		private const EAttributeType ENERGY_ATTR_DOT = EAttributeType.SpecialEnergy2;

		// Token: 0x04023212 RID: 143890
		private const EAttributeType ENERGY_MAX_ATTR_DOT = EAttributeType.SpecialEnergy2Max;

		// Token: 0x04023213 RID: 143891
		private const EAttributeType ENERGY_ATTR_ULT = EAttributeType.SpecialEnergy3;

		// Token: 0x04023214 RID: 143892
		private const EAttributeType ENERGY_MAX_ATTR_ULT = EAttributeType.SpecialEnergy3Max;

		// Token: 0x04023215 RID: 143893
		[Nullable(2)]
		private SpecialEnergyBarSlotItem SlotItem;

		// Token: 0x04023216 RID: 143894
		private readonly List<SpecialEnergyBarInfo> ConfigList = new List<SpecialEnergyBarInfo>();

		// Token: 0x04023217 RID: 143895
		private readonly List<SpecialEnergyBarRuibeikaDot> C1DotItems = new List<SpecialEnergyBarRuibeikaDot>();

		// Token: 0x04023218 RID: 143896
		private readonly List<SpecialEnergyBarRuibeikaDot> C2DotItems = new List<SpecialEnergyBarRuibeikaDot>();

		// Token: 0x04023219 RID: 143897
		private readonly MotorcyclePercentMachine UltCdMachine = new MotorcyclePercentMachine();

		// Token: 0x0402321A RID: 143898
		private float EnergyMaxB = 1f;

		// Token: 0x0402321B RID: 143899
		private float EnergyMaxC = 1f;

		// Token: 0x0402321C RID: 143900
		private SpecialEnergyBarRuibeika.EState CurState;

		// Token: 0x0402321D RID: 143901
		private float BarTipsWidth = 1f;

		// Token: 0x0402321E RID: 143902
		private bool IsDoubleColorMode;

		// Token: 0x0402321F RID: 143903
		private bool DelayedDoubleColorMode;

		// Token: 0x04023220 RID: 143904
		private bool PendingDoubleColorModeSwitch;

		// Token: 0x04023221 RID: 143905
		private float DurationAniUse;

		// Token: 0x04023222 RID: 143906
		[Nullable(2)]
		private TimerHandle TimerHandle;

		// Token: 0x04023223 RID: 143907
		[Nullable(2)]
		private UUISprite UltCdBar;

		// Token: 0x04023224 RID: 143908
		private int UltCdDoneAnim;

		// Token: 0x04023225 RID: 143909
		private int UltLevel;

		// Token: 0x04023226 RID: 143910
		private bool IsUltFinalDone;

		// Token: 0x0200C23A RID: 49722
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403BDD0 RID: 245200
			PnlNor,
			// Token: 0x0403BDD1 RID: 245201
			PnlBarC1,
			// Token: 0x0403BDD2 RID: 245202
			PnlItemC1,
			// Token: 0x0403BDD3 RID: 245203
			PnlBarC2,
			// Token: 0x0403BDD4 RID: 245204
			PnlItemC2,
			// Token: 0x0403BDD5 RID: 245205
			SlotNor,
			// Token: 0x0403BDD6 RID: 245206
			PnlIconGun,
			// Token: 0x0403BDD7 RID: 245207
			PnlIconRifle,
			// Token: 0x0403BDD8 RID: 245208
			PnlUlt,
			// Token: 0x0403BDD9 RID: 245209
			SprUltIcon,
			// Token: 0x0403BDDA RID: 245210
			SprUltBar0,
			// Token: 0x0403BDDB RID: 245211
			SprUltBar1,
			// Token: 0x0403BDDC RID: 245212
			SprUltBar2,
			// Token: 0x0403BDDD RID: 245213
			PnlHotKey,
			// Token: 0x0403BDDE RID: 245214
			AniRedGun,
			// Token: 0x0403BDDF RID: 245215
			AniGreenGun,
			// Token: 0x0403BDE0 RID: 245216
			AniNorToUlt,
			// Token: 0x0403BDE1 RID: 245217
			AniUltToNor,
			// Token: 0x0403BDE2 RID: 245218
			AniState1Done,
			// Token: 0x0403BDE3 RID: 245219
			AniState1To2,
			// Token: 0x0403BDE4 RID: 245220
			AniState2Done,
			// Token: 0x0403BDE5 RID: 245221
			AniState2To3,
			// Token: 0x0403BDE6 RID: 245222
			AniState3Done,
			// Token: 0x0403BDE7 RID: 245223
			AniState3Use,
			// Token: 0x0403BDE8 RID: 245224
			NiaUltGun,
			// Token: 0x0403BDE9 RID: 245225
			PnlUltBar,
			// Token: 0x0403BDEA RID: 245226
			PnlUltCdDone,
			// Token: 0x0403BDEB RID: 245227
			MaxCount
		}

		// Token: 0x0200C23B RID: 49723
		[NullableContext(0)]
		private enum EState
		{
			// Token: 0x0403BDED RID: 245229
			StateGun,
			// Token: 0x0403BDEE RID: 245230
			StateRifle,
			// Token: 0x0403BDEF RID: 245231
			StateUlt
		}
	}
}
