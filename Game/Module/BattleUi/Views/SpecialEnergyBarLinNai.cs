using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060CA RID: 24778
	public class SpecialEnergyBarLinNai : SpecialEnergyBarBase
	{
		// Token: 0x0603E941 RID: 256321 RVA: 0x01002A1C File Offset: 0x01000C1C
		protected override void OnRegisterComponent()
		{
			Dictionary<int, Type> dictionary = new Dictionary<int, Type>();
			dictionary[0] = typeof(UUITexture);
			dictionary[23] = typeof(UUITexture);
			dictionary[1] = typeof(UUIArtText);
			dictionary[2] = typeof(UUIArtText);
			dictionary[6] = typeof(UUISliderComponent);
			Dictionary<int, Type> dictionary2 = dictionary;
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>();
			for (int i = 0; i < 39; i++)
			{
				Type type;
				this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(i, dictionary2.TryGetValue(i, out type) ? type : typeof(UUIItem)));
			}
		}

		// Token: 0x0603E942 RID: 256322 RVA: 0x01002AC8 File Offset: 0x01000CC8
		protected override void OnInitData()
		{
			base.OnInitData();
			this.ConfigList.Add(this.Config);
			this.ConfigList.Add(ModelBase<BattleUiModel>.Instance.SpecialEnergyBarData.GetSpecialEnergyBarInfo(150901));
			this.ConfigList.Add(ModelBase<BattleUiModel>.Instance.SpecialEnergyBarData.GetSpecialEnergyBarInfo(150902));
		}

		// Token: 0x0603E943 RID: 256323 RVA: 0x01002B2C File Offset: 0x01000D2C
		protected override void AddEvents()
		{
			base.AddEvents();
			base.ListenForAttributeChanged(EAttributeType.SpecialEnergy1, new Action<EAttributeType, float, float>(this.AttributeChanged1));
			base.ListenForAttributeChanged(EAttributeType.SpecialEnergy3, new Action<EAttributeType, float, float>(this.AttributeChanged2));
			base.ListenForTagAddOrRemoveChanged(SpecialEnergyBarLinNai.SkateTag, new BaseTagComponent.TTagSwitchedCallback(this.OnTagChanged));
			base.ListenForTagAddOrRemoveChanged(SpecialEnergyBarLinNai.EnergyTag, new BaseTagComponent.TTagSwitchedCallback(this.OnTagChanged));
			base.ListenForTagAddOrRemoveChanged(SpecialEnergyBarLinNai.SubSpeedTag, new BaseTagComponent.TTagSwitchedCallback(this.OnSpeedTagChanged));
			base.ListenForTagAddOrRemoveChanged(SpecialEnergyBarLinNai.MoveTag, new BaseTagComponent.TTagSwitchedCallback(this.OnSpeedTagChanged));
			base.ListenForTagAddOrRemoveChanged(SpecialEnergyBarLinNai.Life6Tag, new BaseTagComponent.TTagSwitchedCallback(this.OnSpeedTagChanged));
			base.ListenForTagAddOrRemoveChanged(SpecialEnergyBarLinNai.EKeyCooldownTag, new BaseTagComponent.TTagSwitchedCallback(this.OnEkeyTagChanged));
			base.ListenForTagAddOrRemoveChanged(SpecialEnergyBarLinNai.EKeyHighlightTag, new BaseTagComponent.TTagSwitchedCallback(this.OnBtnTagChanged));
			base.ListenForTagAddOrRemoveChanged(SpecialEnergyBarLinNai.EKeyActiveTag, new BaseTagComponent.TTagSwitchedCallback(this.OnBtnTagChanged));
			base.ListenForTagAddOrRemoveChanged(SpecialEnergyBarLinNai.SpaceHighlightTag, new BaseTagComponent.TTagSwitchedCallback(this.OnBtnSpaceStateChanged));
		}

		// Token: 0x0603E944 RID: 256324 RVA: 0x01002C38 File Offset: 0x01000E38
		private void AttributeChanged1(EAttributeType attributeId, float newValue, float oldValue)
		{
			this.UpdateEnergyValue(newValue);
			float currentValue = this.AttributeComponent.GetCurrentValue(EAttributeType.SpecialEnergy1Max);
			if ((double)(Math.Abs(newValue - oldValue) / currentValue) > 0.3)
			{
				this.NeedleFx.ForceTo(newValue / currentValue);
				this.IsEnergySpeedDirty = true;
				return;
			}
			if ((this.CurState == SpecialEnergyBarLinNai.EState.EnergyState && (double)Math.Abs(this.NeedleFx.Get() - newValue / currentValue) > 0.2) || (this.CurState == SpecialEnergyBarLinNai.EState.JumpState && (double)Math.Abs(this.NeedleFx.Get() - newValue / currentValue) > 0.1))
			{
				this.NeedleFx.ForceTo(newValue / currentValue);
				this.IsEnergySpeedDirty = true;
			}
		}

		// Token: 0x0603E945 RID: 256325 RVA: 0x01002CED File Offset: 0x01000EED
		private void AttributeChanged2(EAttributeType attributeId, float newValue, float oldValue)
		{
			this.UpdateJumpValue(new float?(newValue));
		}

		// Token: 0x0603E946 RID: 256326 RVA: 0x01002CFB File Offset: 0x01000EFB
		private void OnTagChanged(int tagId, bool tagExist)
		{
			this.RefreshState(false);
		}

		// Token: 0x0603E947 RID: 256327 RVA: 0x01002D04 File Offset: 0x01000F04
		private void OnBtnSpaceStateChanged(int tagId, bool tagExist)
		{
			this.SwitchKeyItem();
		}

		// Token: 0x0603E948 RID: 256328 RVA: 0x01002D0C File Offset: 0x01000F0C
		private void OnBtnTagChanged(int tagId, bool tagExist)
		{
			this.SwitchKeyItem();
		}

		// Token: 0x0603E949 RID: 256329 RVA: 0x01002D14 File Offset: 0x01000F14
		private void OnEkeyTagChanged(int tagId, bool tagExist)
		{
			this.RefreshInCdFx(true);
		}

		// Token: 0x0603E94A RID: 256330 RVA: 0x01002D20 File Offset: 0x01000F20
		protected override UniTask OnBeforeStartAsync()
		{
			SpecialEnergyBarLinNai.<OnBeforeStartAsync>d__49 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SpecialEnergyBarLinNai.<OnBeforeStartAsync>d__49>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603E94B RID: 256331 RVA: 0x01002D64 File Offset: 0x01000F64
		protected UniTask InitBarItem()
		{
			SpecialEnergyBarLinNai.<InitBarItem>d__50 <InitBarItem>d__;
			<InitBarItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitBarItem>d__.<>4__this = this;
			<InitBarItem>d__.<>1__state = -1;
			<InitBarItem>d__.<>t__builder.Start<SpecialEnergyBarLinNai.<InitBarItem>d__50>(ref <InitBarItem>d__);
			return <InitBarItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603E94C RID: 256332 RVA: 0x01002DA8 File Offset: 0x01000FA8
		protected override void OnStart()
		{
			base.OnStart();
			for (int i = 24; i <= 38; i++)
			{
				base.InitTweenAnim(i);
			}
			BattleUiTweenAnimPlayer tweenAnimPlayer = this.TweenAnimPlayer;
			this.DurationC2A = (int)(((tweenAnimPlayer != null) ? tweenAnimPlayer.GetDuration(30) : 0.3f) * 1000f);
		}

		// Token: 0x0603E94D RID: 256333 RVA: 0x01002DF8 File Offset: 0x01000FF8
		protected override void OnBeforeShow()
		{
			base.OnBeforeShow();
			this.RefreshState(true);
			this.RefreshInCdFx(true);
			if (this.CurState == SpecialEnergyBarLinNai.EState.PaintState)
			{
				float percent = this.AttributeComponent.GetCurrentValue(EAttributeType.SpecialEnergy2) / this.AttributeComponent.GetCurrentValue(EAttributeType.SpecialEnergy2Max);
				this.UpdatePaintPercent(percent);
				return;
			}
			this.UpdateJumpValue(null);
			this.UpdateEnergySpeed();
			this.TickEnergyPercent(0f);
		}

		// Token: 0x0603E94E RID: 256334 RVA: 0x01002E65 File Offset: 0x01001065
		protected override void ClearAllTweenAnim()
		{
			BattleUiTweenAnimPlayer tweenAnimPlayer = this.TweenAnimPlayer;
			if (tweenAnimPlayer != null)
			{
				tweenAnimPlayer.Clear(true);
			}
			base.ClearAllTweenAnim();
		}

		// Token: 0x0603E94F RID: 256335 RVA: 0x01002E80 File Offset: 0x01001080
		protected override void OnBarPercentChanged()
		{
			float curPercent = this.PercentMachine.GetCurPercent();
			this.UpdatePaintPercent(curPercent);
		}

		// Token: 0x0603E950 RID: 256336 RVA: 0x01002EA0 File Offset: 0x010010A0
		private void RefreshState(bool isStart = false)
		{
			if (this.TagComponent.HasTag(SpecialEnergyBarLinNai.EnergyTag))
			{
				this.SetState(SpecialEnergyBarLinNai.EState.EnergyState, isStart);
				return;
			}
			if (this.TagComponent.HasTag(SpecialEnergyBarLinNai.SkateTag))
			{
				this.SetState(SpecialEnergyBarLinNai.EState.JumpState, isStart);
				return;
			}
			this.SetState(SpecialEnergyBarLinNai.EState.PaintState, isStart);
		}

		// Token: 0x0603E951 RID: 256337 RVA: 0x01002EE0 File Offset: 0x010010E0
		private void SetState(SpecialEnergyBarLinNai.EState state, bool isStart = false)
		{
			if (state == this.CurState && !isStart)
			{
				return;
			}
			SpecialEnergyBarLinNai.EState curState = this.CurState;
			this.CurState = state;
			this.LastPaintPercent = 0f;
			float currentValue = this.AttributeComponent.GetCurrentValue(EAttributeType.SpecialEnergy1);
			float currentValue2 = this.AttributeComponent.GetCurrentValue(EAttributeType.SpecialEnergy1Max);
			BattleUiTweenAnimPlayer tweenAnimPlayer = this.TweenAnimPlayer;
			if (tweenAnimPlayer != null)
			{
				tweenAnimPlayer.StopAll();
			}
			bool flag = state == SpecialEnergyBarLinNai.EState.PaintState;
			base.GetArtText(2).SetUIActive(!flag);
			switch (state)
			{
			case SpecialEnergyBarLinNai.EState.PaintState:
			{
				this.PlayedStartA = false;
				float currentValue3 = this.AttributeComponent.GetCurrentValue(EAttributeType.SpecialEnergy2);
				float inValue = currentValue3 / this.AttributeComponent.GetCurrentValue(EAttributeType.SpecialEnergy2Max);
				base.GetSlider(6).SetValue(inValue, true);
				base.GetArtText(1).SetText("000");
				if (curState == SpecialEnergyBarLinNai.EState.JumpState)
				{
					base.PlayTweenAnim(30);
					if (currentValue3 > 0f)
					{
						this.TimerStartA = TimerSystem.Instance.Delay(delegate(float _)
						{
							this.TimerStartA = null;
							if (state == SpecialEnergyBarLinNai.EState.PaintState)
							{
								this.PlayedStartA = true;
								this.PlayTweenAnim(24);
							}
						}, (float)this.DurationC2A, null, null, true, ModelBase<CharacterModel>.Instance.InverseSelfCenteredTimeDilation);
					}
				}
				else if (currentValue3 > 0f)
				{
					this.PlayedStartA = true;
					base.PlayTweenAnim(24);
				}
				break;
			}
			case SpecialEnergyBarLinNai.EState.EnergyState:
				this.NeedleFx.SetCurrent(currentValue / currentValue2);
				this.IsEnergySpeedDirty = true;
				base.PlayTweenAnim(25);
				break;
			case SpecialEnergyBarLinNai.EState.JumpState:
				this.NeedleFx.SetCurrent(currentValue / currentValue2);
				this.IsEnergySpeedDirty = true;
				base.PlayTweenAnim((curState == SpecialEnergyBarLinNai.EState.PaintState) ? 36 : 26);
				break;
			}
			this.UpdateJumpValueState();
			this.RefreshInCdFx(false);
			this.SwitchKeyItem();
		}

		// Token: 0x0603E952 RID: 256338 RVA: 0x0100309C File Offset: 0x0100129C
		private void RefreshInCdFx(bool force = false)
		{
			BaseTagComponent tagComponent = this.TagComponent;
			bool flag = tagComponent != null && tagComponent.HasTag(SpecialEnergyBarLinNai.EKeyCooldownTag);
			if (force || this.IsInCdFx != flag)
			{
				base.PlayTweenAnim(flag ? 38 : 37);
			}
			this.IsInCdFx = flag;
		}

		// Token: 0x0603E953 RID: 256339 RVA: 0x010030E3 File Offset: 0x010012E3
		internal bool Internal_GetKeyEnable()
		{
			return this.GetKeyEnable();
		}

		// Token: 0x0603E954 RID: 256340 RVA: 0x010030EC File Offset: 0x010012EC
		protected override bool GetKeyEnable()
		{
			if (this.CurState == SpecialEnergyBarLinNai.EState.PaintState)
			{
				return base.GetKeyEnable();
			}
			return this.CurState == SpecialEnergyBarLinNai.EState.EnergyState || this.TagComponent.HasTag(SpecialEnergyBarLinNai.SpaceHighlightTag) || this.TagComponent.HasTag(SpecialEnergyBarLinNai.EKeyHighlightTag) || this.TagComponent.HasTag(SpecialEnergyBarLinNai.EKeyActiveTag);
		}

		// Token: 0x0603E955 RID: 256341 RVA: 0x0100314C File Offset: 0x0100134C
		private void SwitchKeyItem()
		{
			if (this.CurState != SpecialEnergyBarLinNai.EState.JumpState)
			{
				SpecialEnergyBarLinNaiSlot barSlot = this.BarSlot;
				if (barSlot != null)
				{
					barSlot.SwitchKeyItem(this.ConfigList[0], false);
				}
				if (this.CurState == SpecialEnergyBarLinNai.EState.EnergyState)
				{
					SpecialEnergyBarLinNaiSlot barSlot2 = this.BarSlot;
					if (barSlot2 == null)
					{
						return;
					}
					barSlot2.RefreshKeyEnable(true, true);
				}
				return;
			}
			if (this.TagComponent.HasTag(SpecialEnergyBarLinNai.EKeyHighlightTag) || this.TagComponent.HasTag(SpecialEnergyBarLinNai.EKeyActiveTag))
			{
				SpecialEnergyBarLinNaiSlot barSlot3 = this.BarSlot;
				if (barSlot3 != null)
				{
					barSlot3.SwitchKeyItem(this.ConfigList[2], true);
				}
				SpecialEnergyBarLinNaiSlot barSlot4 = this.BarSlot;
				if (barSlot4 == null)
				{
					return;
				}
				barSlot4.RefreshKeyEnable(true, true);
				return;
			}
			else
			{
				SpecialEnergyBarLinNaiSlot barSlot5 = this.BarSlot;
				if (barSlot5 != null)
				{
					barSlot5.SwitchKeyItem(this.ConfigList[1], true);
				}
				SpecialEnergyBarLinNaiSlot barSlot6 = this.BarSlot;
				if (barSlot6 == null)
				{
					return;
				}
				barSlot6.RefreshKeyEnable(this.TagComponent.HasTag(SpecialEnergyBarLinNai.SpaceHighlightTag), true);
				return;
			}
		}

		// Token: 0x0603E956 RID: 256342 RVA: 0x01003234 File Offset: 0x01001434
		private void UpdatePaintPercent(float percent)
		{
			if (this.CurState != SpecialEnergyBarLinNai.EState.EnergyState || percent == 0f)
			{
				base.GetSlider(6).SetValue(percent, true);
			}
			if (this.CurState == SpecialEnergyBarLinNai.EState.PaintState)
			{
				if (this.LastPaintPercent < 1f && percent >= 1f)
				{
					base.PlayTweenAnim(32);
				}
				else if (!this.PlayedStartA && this.TimerStartA == null)
				{
					this.PlayedStartA = true;
					base.PlayTweenAnim(24);
				}
			}
			this.LastPaintPercent = percent;
		}

		// Token: 0x0603E957 RID: 256343 RVA: 0x010032B8 File Offset: 0x010014B8
		private void OnSpeedTagChanged(int tagId, bool tagExist)
		{
			if (tagId == SpecialEnergyBarLinNai.MoveTag && this.TagComponent.HasTag(SpecialEnergyBarLinNai.DashTag))
			{
				if (!tagExist)
				{
					this.PendingMoveFlag = true;
					this.TimerMoveFlag = TimerSystem.Instance.Delay(delegate(float _)
					{
						this.TimerMoveFlag = null;
						this.PendingMoveFlag = false;
						this.IsEnergySpeedDirty = true;
					}, 50f, null, null, true, ModelBase<CharacterModel>.Instance.InverseSelfCenteredTimeDilation);
				}
				else
				{
					this.PendingMoveFlag = false;
				}
			}
			this.IsEnergySpeedDirty = true;
		}

		// Token: 0x0603E958 RID: 256344 RVA: 0x01003328 File Offset: 0x01001528
		private void UpdateEnergySpeed()
		{
			this.IsEnergySpeedDirty = false;
			if (this.CurState == SpecialEnergyBarLinNai.EState.EnergyState)
			{
				Buff? config = ConfigBuffById.GetConfig(this.TagComponent.HasTag(SpecialEnergyBarLinNai.Life6Tag) ? 15090000129L : 15090000104L, true);
				int num = (config != null) ? config.GetValueOrDefault().ModifierMagnitude(0) : 0;
				if ((float)Math.Abs(num) > 1E-45f)
				{
					float currentValue = this.AttributeComponent.GetCurrentValue(EAttributeType.SpecialEnergy1Max);
					this.NeedleFx.SetSpeed((float)num / currentValue / 0.2f, true);
				}
				else
				{
					this.NeedleFx.SetSpeed(0.7f, true);
				}
				this.FixEnergyValue();
				return;
			}
			if (this.CurState == SpecialEnergyBarLinNai.EState.JumpState)
			{
				long num2 = 0L;
				bool flag = this.TagComponent.HasTag(SpecialEnergyBarLinNai.MoveTag) || this.PendingMoveFlag;
				bool flag2 = this.TagComponent.HasTag(SpecialEnergyBarLinNai.SubSpeedTag);
				if (flag && flag2)
				{
					this.FixEnergyValue();
					this.NeedleFx.SetSpeed(0f, false);
				}
				else if (flag)
				{
					num2 = (this.TagComponent.HasTag(SpecialEnergyBarLinNai.Life6Tag) ? 15090000149L : 15090000142L);
				}
				else if (flag2)
				{
					num2 = (this.TagComponent.HasTag(SpecialEnergyBarLinNai.Life6Tag) ? 15090000148L : 15090000141L);
				}
				else
				{
					this.FixEnergyValue();
					this.NeedleFx.SetSpeed(0f, false);
				}
				if (num2 != 0L)
				{
					Buff? config = ConfigBuffById.GetConfig(num2, true);
					int num3 = (config != null) ? config.GetValueOrDefault().ModifierMagnitude(0) : 0;
					if (num3 != 0)
					{
						float v = (float)num3 / 0.2f / this.AttributeComponent.GetCurrentValue(EAttributeType.SpecialEnergy1Max);
						this.NeedleFx.SetTargetMode(false);
						this.NeedleFx.SetSpeed(v, false);
						return;
					}
					this.FixEnergyValue();
				}
			}
		}

		// Token: 0x0603E959 RID: 256345 RVA: 0x0100351C File Offset: 0x0100171C
		private void FixEnergyValue()
		{
			float targetEnergyPct = this.TargetEnergyPct;
			this.NeedleFx.SetTargetMode(true);
			this.NeedleFx.ResetTarget(targetEnergyPct, null);
		}

		// Token: 0x0603E95A RID: 256346 RVA: 0x01003554 File Offset: 0x01001754
		private void UpdateEnergyValue(float curr)
		{
			float targetEnergyPct = curr / this.AttributeComponent.GetCurrentValue(EAttributeType.SpecialEnergy1Max);
			if (this.NeedleFx.IsDone())
			{
				this.NeedleFx.Restart();
			}
			this.TargetEnergyPct = targetEnergyPct;
			if (this.CurState == SpecialEnergyBarLinNai.EState.EnergyState)
			{
				this.FixEnergyValue();
			}
		}

		// Token: 0x0603E95B RID: 256347 RVA: 0x010035A0 File Offset: 0x010017A0
		private void TickEnergyPercent(float delta)
		{
			if (this.CurState == SpecialEnergyBarLinNai.EState.PaintState)
			{
				return;
			}
			if (this.IsEnergySpeedDirty)
			{
				this.UpdateEnergySpeed();
			}
			if (!this.NeedleFx.IsDone())
			{
				CharacterBuffComponent buffComponent = this.BuffComponent;
				float num = (buffComponent != null) ? buffComponent.GetTimeScale() : 1f;
				this.NeedleFx.Tick(delta * 0.001f * num);
				float num2 = this.NeedleFx.Get();
				num2 = MathCommon.Clamp(num2, 0f, 1f);
				float num3 = MathCommon.Lerp(0.437f, 0.562f, num2);
				if (num3 >= 0.562f)
				{
					num3 = 0.58f;
				}
				base.GetTexture(0).SetFillAmount(num3);
				base.GetTexture(23).SetFillAmount(num3);
				FRotator frotator = new FRotator
				{
					Yaw = MathCommon.Lerp(15f, -15f, num2)
				};
				base.GetItem(18).SetUIRelativeRotation(frotator);
				int num4 = (int)Math.Floor((double)(this.AttributeComponent.GetCurrentValue(EAttributeType.SpecialEnergy1Max) / 100f * num2));
				base.GetArtText(1).SetText(num4.ToString().PadLeft(3, '0'));
				base.GetArtText(2).SetText(num4.ToString());
				if (this.TargetEnergyPct >= 1f && this.NeedleFx.IsDone() && this.CurState == SpecialEnergyBarLinNai.EState.EnergyState)
				{
					base.PlayTweenAnim(31);
				}
				if (this.CurState == SpecialEnergyBarLinNai.EState.EnergyState)
				{
					num2 = 1f - num2;
					float curPercent = this.PercentMachine.GetCurPercent();
					if ((double)Math.Abs(num2 - curPercent) > 0.2)
					{
						num2 = MathCommon.Clamp(num2, curPercent - 0.2f, curPercent + 0.2f);
					}
					base.GetSlider(6).SetValue(num2, true);
				}
			}
		}

		// Token: 0x0603E95C RID: 256348 RVA: 0x01003758 File Offset: 0x01001958
		private void UpdateJumpValue(float? value = null)
		{
			float num = value ?? this.AttributeComponent.GetCurrentValue(EAttributeType.SpecialEnergy3);
			if (this.CurState == SpecialEnergyBarLinNai.EState.JumpState)
			{
				for (int i = 1; i <= 3; i++)
				{
					int num3;
					if ((float)i <= num)
					{
						int num2;
						if (!this.LastJumpValueMap.TryGetValue(i, out num2) || num2 != 1)
						{
							this.LastJumpValueMap[i] = 1;
							base.PlayTweenAnim(this.JumpAnimAddMap[i]);
						}
					}
					else if (!this.LastJumpValueMap.TryGetValue(i, out num3) || num3 != -1)
					{
						this.LastJumpValueMap[i] = -1;
						base.PlayTweenAnim(this.JumpAnimReduceMap[i]);
					}
				}
				return;
			}
			for (int j = 1; j <= 3; j++)
			{
				int num4;
				if (!this.LastJumpValueMap.TryGetValue(j, out num4) || num4 != -1)
				{
					this.LastJumpValueMap[j] = -1;
					base.PlayTweenAnim(this.JumpAnimReduceMap[j]);
				}
			}
		}

		// Token: 0x0603E95D RID: 256349 RVA: 0x01003854 File Offset: 0x01001A54
		private void UpdateJumpValueState()
		{
			this.UpdateJumpValue(null);
			UUIItem item = base.GetItem(10);
			if (item != null)
			{
				item.SetUIActive(this.CurState == SpecialEnergyBarLinNai.EState.JumpState);
			}
			UUIItem item2 = base.GetItem(12);
			if (item2 != null)
			{
				item2.SetUIActive(this.CurState == SpecialEnergyBarLinNai.EState.JumpState);
			}
			UUIItem item3 = base.GetItem(14);
			if (item3 == null)
			{
				return;
			}
			item3.SetUIActive(this.CurState == SpecialEnergyBarLinNai.EState.JumpState);
		}

		// Token: 0x0603E95E RID: 256350 RVA: 0x010038C3 File Offset: 0x01001AC3
		public override void Tick(float delta)
		{
			base.Tick(delta);
			SpecialEnergyBarLinNaiSlot barSlot = this.BarSlot;
			if (barSlot != null)
			{
				barSlot.Tick(delta);
			}
			this.TickEnergyPercent(delta);
		}

		// Token: 0x0603E95F RID: 256351 RVA: 0x010038E8 File Offset: 0x01001AE8
		protected override void OnBeforeDestroy()
		{
			if (this.TimerStartA != null)
			{
				TimerSystem.Instance.Remove(this.TimerStartA);
				this.TimerStartA = null;
			}
			if (this.TimerMoveFlag != null)
			{
				TimerSystem.Instance.Remove(this.TimerMoveFlag);
				this.TimerMoveFlag = null;
			}
			base.OnBeforeDestroy();
		}

		// Token: 0x04023165 RID: 143717
		private const EAttributeType PAINT_ATTR_ID = EAttributeType.SpecialEnergy2;

		// Token: 0x04023166 RID: 143718
		private const EAttributeType PAINT_MAX_ATTR_ID = EAttributeType.SpecialEnergy2Max;

		// Token: 0x04023167 RID: 143719
		private const EAttributeType ENERGY_ATTR_ID = EAttributeType.SpecialEnergy1;

		// Token: 0x04023168 RID: 143720
		private const EAttributeType ENERGY_MAX_ATTR_ID = EAttributeType.SpecialEnergy1Max;

		// Token: 0x04023169 RID: 143721
		private const EAttributeType JUMP_ATTR_ID = EAttributeType.SpecialEnergy3;

		// Token: 0x0402316A RID: 143722
		private const int SPACEBTN_CONFIG = 150901;

		// Token: 0x0402316B RID: 143723
		private const int E_SPACEBTN_CONFIG = 150902;

		// Token: 0x0402316C RID: 143724
		private const float ENERGY_DELTA_SEC = 0.2f;

		// Token: 0x0402316D RID: 143725
		private const int CHECK_LOST_MOVETAG = 50;

		// Token: 0x0402316E RID: 143726
		[StaticVariableRuleIgnore]
		private static readonly int MoveTag = GameplayTagDefine.EGameplayTagId["角色.LinnaiMd10011.加速度值0"];

		// Token: 0x0402316F RID: 143727
		[StaticVariableRuleIgnore]
		private static readonly int DashTag = GameplayTagDefine.EGameplayTagId["行为状态.动作状态.冲刺"];

		// Token: 0x04023170 RID: 143728
		[StaticVariableRuleIgnore]
		private static readonly int SubSpeedTag = GameplayTagDefine.EGameplayTagId["角色.LinnaiMd10011.减速度值0"];

		// Token: 0x04023171 RID: 143729
		[StaticVariableRuleIgnore]
		private static readonly int Life6Tag = GameplayTagDefine.EGameplayTagId["角色.LinnaiMd10011.共鸣.共鸣6"];

		// Token: 0x04023172 RID: 143730
		[StaticVariableRuleIgnore]
		private static readonly int SkateTag = GameplayTagDefine.EGameplayTagId["角色.LinnaiMd10011.轮滑状态"];

		// Token: 0x04023173 RID: 143731
		[StaticVariableRuleIgnore]
		private static readonly int EnergyTag = GameplayTagDefine.EGameplayTagId["角色.LinnaiMd10011.轮滑蓄力"];

		// Token: 0x04023174 RID: 143732
		[StaticVariableRuleIgnore]
		private static readonly int EKeyCooldownTag = GameplayTagDefine.EGameplayTagId["角色.LinnaiMd10011.下砸冷却"];

		// Token: 0x04023175 RID: 143733
		[StaticVariableRuleIgnore]
		private static readonly int EKeyHighlightTag = GameplayTagDefine.EGameplayTagId["角色.LinnaiMd10011.飞跃下砸按钮高亮"];

		// Token: 0x04023176 RID: 143734
		[StaticVariableRuleIgnore]
		private static readonly int EKeyActiveTag = GameplayTagDefine.EGameplayTagId["角色.LinnaiMd10011.激活飞跃下砸标记"];

		// Token: 0x04023177 RID: 143735
		[StaticVariableRuleIgnore]
		private static readonly int SpaceHighlightTag = GameplayTagDefine.EGameplayTagId["角色.LinnaiMd10011.常态.跳跃按钮高亮"];

		// Token: 0x04023178 RID: 143736
		[Nullable(2)]
		private SpecialEnergyBarLinNaiSlot BarSlot;

		// Token: 0x04023179 RID: 143737
		private SpecialEnergyBarLinNai.EState CurState;

		// Token: 0x0402317A RID: 143738
		[Nullable(1)]
		private readonly List<SpecialEnergyBarInfo> ConfigList = new List<SpecialEnergyBarInfo>();

		// Token: 0x0402317B RID: 143739
		private int DurationC2A = 300;

		// Token: 0x0402317C RID: 143740
		[Nullable(2)]
		private TimerHandle TimerStartA;

		// Token: 0x0402317D RID: 143741
		private bool PlayedStartA;

		// Token: 0x0402317E RID: 143742
		private float LastPaintPercent;

		// Token: 0x0402317F RID: 143743
		private float TargetEnergyPct;

		// Token: 0x04023180 RID: 143744
		[Nullable(1)]
		private readonly SpecialEnergyBarLinNai.NeedleNumber NeedleFx = new SpecialEnergyBarLinNai.NeedleNumber();

		// Token: 0x04023181 RID: 143745
		private bool IsEnergySpeedDirty;

		// Token: 0x04023182 RID: 143746
		private bool PendingMoveFlag;

		// Token: 0x04023183 RID: 143747
		[Nullable(2)]
		private TimerHandle TimerMoveFlag;

		// Token: 0x04023184 RID: 143748
		[Nullable(1)]
		private readonly Dictionary<int, int> LastJumpValueMap = new Dictionary<int, int>();

		// Token: 0x04023185 RID: 143749
		[Nullable(1)]
		private readonly Dictionary<int, int> JumpAnimAddMap = new Dictionary<int, int>
		{
			{
				1,
				27
			},
			{
				2,
				28
			},
			{
				3,
				29
			}
		};

		// Token: 0x04023186 RID: 143750
		[Nullable(1)]
		private readonly Dictionary<int, int> JumpAnimReduceMap = new Dictionary<int, int>
		{
			{
				1,
				33
			},
			{
				2,
				34
			},
			{
				3,
				35
			}
		};

		// Token: 0x04023187 RID: 143751
		private bool IsInCdFx;

		// Token: 0x0200C206 RID: 49670
		private class NeedleNumber
		{
			// Token: 0x0604E5D2 RID: 320978 RVA: 0x015B8DEE File Offset: 0x015B6FEE
			public void SetTargetMode(bool b)
			{
				this.IsTargetMode = b;
			}

			// Token: 0x0604E5D3 RID: 320979 RVA: 0x015B8DF8 File Offset: 0x015B6FF8
			public void ResetTarget(float t1, float? t2 = null)
			{
				this.TargetIndex = 0;
				this.Targets.Clear();
				this.Targets.Add(t1);
				if (t2 != null)
				{
					this.Targets.Add(t2.Value);
				}
				this.SpeedInner = Math.Abs(this.SpeedInner);
			}

			// Token: 0x1700AA3D RID: 43581
			// (get) Token: 0x0604E5D4 RID: 320980 RVA: 0x015B8E4F File Offset: 0x015B704F
			public float Speed
			{
				get
				{
					return this.SpeedInner;
				}
			}

			// Token: 0x0604E5D5 RID: 320981 RVA: 0x015B8E58 File Offset: 0x015B7058
			public void SetSpeed(float v, bool force = false)
			{
				if (this.IsTargetMode)
				{
					v = Math.Abs(v);
				}
				this.SpeedNext = v;
				if (force || !this.IsTargetMode || (this.IsTargetMode && (this.IsDone() || v != 0f)))
				{
					this.SpeedInner = v;
				}
			}

			// Token: 0x0604E5D6 RID: 320982 RVA: 0x015B8EA6 File Offset: 0x015B70A6
			public void SetCurrent(float v)
			{
				this.NeedUpdate = (this.Current != v);
				this.Current = v;
			}

			// Token: 0x0604E5D7 RID: 320983 RVA: 0x015B8EC4 File Offset: 0x015B70C4
			public void ForceTo(float v)
			{
				this.SetCurrent(v);
				if (this.IsTargetMode)
				{
					this.ResetTarget(v, null);
				}
			}

			// Token: 0x0604E5D8 RID: 320984 RVA: 0x015B8EF0 File Offset: 0x015B70F0
			public void Restart()
			{
				if (!this.IsTargetMode)
				{
					this.SetCurrent(MathCommon.Clamp(this.Current, 0f, 1f));
				}
			}

			// Token: 0x0604E5D9 RID: 320985 RVA: 0x015B8F18 File Offset: 0x015B7118
			public bool IsDone()
			{
				if (this.IsTargetMode)
				{
					return !this.NeedUpdate && this.TargetIndex >= this.Targets.Count;
				}
				return !this.NeedUpdate && (this.SpeedInner == 0f || this.Current < 0f || this.Current > 1f);
			}

			// Token: 0x0604E5DA RID: 320986 RVA: 0x015B8F84 File Offset: 0x015B7184
			public void Tick(float delta)
			{
				if (this.IsTargetMode)
				{
					if (this.TargetIndex >= this.Targets.Count)
					{
						return;
					}
					float num = this.Targets[this.TargetIndex];
					int num2 = Math.Sign(num - this.Current);
					this.Current += (float)num2 * this.SpeedInner * delta;
					if ((num2 > 0 && this.Current >= num) || (num2 < 0 && this.Current <= num))
					{
						this.Current = num;
						this.SpeedInner = this.SpeedNext;
						this.TargetIndex++;
					}
				}
				else
				{
					this.Current += this.SpeedInner * delta;
				}
				this.NeedUpdate = false;
			}

			// Token: 0x0604E5DB RID: 320987 RVA: 0x015B9041 File Offset: 0x015B7241
			public float Get()
			{
				return this.Current;
			}

			// Token: 0x0403BC7E RID: 244862
			private bool IsTargetMode = true;

			// Token: 0x0403BC7F RID: 244863
			private float Current;

			// Token: 0x0403BC80 RID: 244864
			[Nullable(1)]
			private readonly List<float> Targets = new List<float>();

			// Token: 0x0403BC81 RID: 244865
			private int TargetIndex;

			// Token: 0x0403BC82 RID: 244866
			private float SpeedInner = 1f;

			// Token: 0x0403BC83 RID: 244867
			private float SpeedNext = 1f;

			// Token: 0x0403BC84 RID: 244868
			private bool NeedUpdate;
		}

		// Token: 0x0200C207 RID: 49671
		private enum EState
		{
			// Token: 0x0403BC86 RID: 244870
			PaintState,
			// Token: 0x0403BC87 RID: 244871
			EnergyState,
			// Token: 0x0403BC88 RID: 244872
			JumpState
		}

		// Token: 0x0200C208 RID: 49672
		private enum EChildType
		{
			// Token: 0x0403BC8A RID: 244874
			RechareBar,
			// Token: 0x0403BC8B RID: 244875
			ArtTxtBlack,
			// Token: 0x0403BC8C RID: 244876
			ArtTxtLight,
			// Token: 0x0403BC8D RID: 244877
			PnlLight,
			// Token: 0x0403BC8E RID: 244878
			PnlWheel,
			// Token: 0x0403BC8F RID: 244879
			SlotBarItem,
			// Token: 0x0403BC90 RID: 244880
			SubWheel,
			// Token: 0x0403BC91 RID: 244881
			SubWheelBgL,
			// Token: 0x0403BC92 RID: 244882
			SubWheelBgR,
			// Token: 0x0403BC93 RID: 244883
			PnlSlot1,
			// Token: 0x0403BC94 RID: 244884
			PnlSlot1Hor1,
			// Token: 0x0403BC95 RID: 244885
			PnlSlot1Hor1Dot,
			// Token: 0x0403BC96 RID: 244886
			PnlSlot1Hor2,
			// Token: 0x0403BC97 RID: 244887
			PnlSlot1Hor2Dot,
			// Token: 0x0403BC98 RID: 244888
			PnlSlot1Hor3,
			// Token: 0x0403BC99 RID: 244889
			PnlSlot1Hor3Dot,
			// Token: 0x0403BC9A RID: 244890
			SprLine1,
			// Token: 0x0403BC9B RID: 244891
			SprLine2,
			// Token: 0x0403BC9C RID: 244892
			PnlNeedle,
			// Token: 0x0403BC9D RID: 244893
			FxSprLine1,
			// Token: 0x0403BC9E RID: 244894
			FxSprLine2,
			// Token: 0x0403BC9F RID: 244895
			FxNiaJump1,
			// Token: 0x0403BCA0 RID: 244896
			FxNiaJump2,
			// Token: 0x0403BCA1 RID: 244897
			RechareBarBg,
			// Token: 0x0403BCA2 RID: 244898
			AnimStartA,
			// Token: 0x0403BCA3 RID: 244899
			AnimStartB,
			// Token: 0x0403BCA4 RID: 244900
			AnimStartC,
			// Token: 0x0403BCA5 RID: 244901
			AnimNl1,
			// Token: 0x0403BCA6 RID: 244902
			AnimNl2,
			// Token: 0x0403BCA7 RID: 244903
			AnimNl3,
			// Token: 0x0403BCA8 RID: 244904
			AnimStartC2A,
			// Token: 0x0403BCA9 RID: 244905
			AnimBMax,
			// Token: 0x0403BCAA RID: 244906
			AnimAMax,
			// Token: 0x0403BCAB RID: 244907
			AnimNlOut1,
			// Token: 0x0403BCAC RID: 244908
			AnimNlOut2,
			// Token: 0x0403BCAD RID: 244909
			AnimNlOut3,
			// Token: 0x0403BCAE RID: 244910
			AnimStartA2C,
			// Token: 0x0403BCAF RID: 244911
			AnimEKeyIn,
			// Token: 0x0403BCB0 RID: 244912
			AnimEKeyOut,
			// Token: 0x0403BCB1 RID: 244913
			MaxCount
		}

		// Token: 0x0200C209 RID: 49673
		private enum EEnergySpeedPhase2 : long
		{
			// Token: 0x0403BCB3 RID: 244915
			Life0 = 15090000104L,
			// Token: 0x0403BCB4 RID: 244916
			Life6 = 15090000129L
		}

		// Token: 0x0200C20A RID: 49674
		private enum EEnergySpeedPhase3 : long
		{
			// Token: 0x0403BCB6 RID: 244918
			Life0Sub = 15090000141L,
			// Token: 0x0403BCB7 RID: 244919
			Life0Add,
			// Token: 0x0403BCB8 RID: 244920
			Life6Sub = 15090000148L,
			// Token: 0x0403BCB9 RID: 244921
			Life6Add
		}
	}
}
