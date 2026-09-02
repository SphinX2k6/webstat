using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.QuickHack.View
{
	// Token: 0x02005305 RID: 21253
	[NullableContext(1)]
	[Nullable(0)]
	public class BattleQuickHackView : QuickHackViewBase
	{
		// Token: 0x06036410 RID: 222224 RVA: 0x00DAC175 File Offset: 0x00DAA375
		public BattleQuickHackView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06036411 RID: 222225 RVA: 0x00DAC180 File Offset: 0x00DAA380
		protected unsafe override void OnRegisterComponent()
		{
			int num = 36;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(16, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(19, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(20, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(21, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(22, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(23, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(24, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(25, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(26, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(27, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(28, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(29, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(30, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(31, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(32, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(33, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(34, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(35, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06036412 RID: 222226 RVA: 0x00DAC668 File Offset: 0x00DAA868
		protected override int GetUiComponentType(EQuickHackUiType uiType)
		{
			switch (uiType)
			{
			case EQuickHackUiType.RamItem:
				return 2;
			case EQuickHackUiType.SkillPanelLayout:
				return 5;
			case EQuickHackUiType.RamTitleText:
				return 0;
			case EQuickHackUiType.TipItem:
				return 3;
			case EQuickHackUiType.TipText:
				return 4;
			case EQuickHackUiType.InfoTitleText:
				return 8;
			case EQuickHackUiType.InfoTagText:
				return 10;
			case EQuickHackUiType.InfoDescText:
				return 13;
			case EQuickHackUiType.InfoDurationText:
				return 11;
			case EQuickHackUiType.InfoUploadText:
				return 12;
			case EQuickHackUiType.DurationLimitItem:
				return 14;
			case EQuickHackUiType.DurationLimitBarSprite:
				return 16;
			case EQuickHackUiType.DurationLimitText:
				return 15;
			case EQuickHackUiType.TargetItem:
				return 21;
			case EQuickHackUiType.RamSpriteDarkBlue:
				return 22;
			case EQuickHackUiType.RamSpriteBlue:
				return 23;
			case EQuickHackUiType.RamSpriteRedA:
				return 24;
			case EQuickHackUiType.RamSpriteRedB:
				return 25;
			case EQuickHackUiType.UseSkillKeyItem:
				return 27;
			case EQuickHackUiType.InfoLineItem:
				return 29;
			default:
				return -1;
			}
		}

		// Token: 0x06036413 RID: 222227 RVA: 0x00DAC704 File Offset: 0x00DAA904
		protected override void RefreshInput(bool enable)
		{
			if (enable)
			{
				UUIButtonComponent button = base.GetButton(17);
				button.OnPointDownCallBack.Bind(new Action(this.UseSkillPress));
				button.OnPointUpCallBack.Bind(new Action(this.UseSkillRelease));
				button.OnPointCancelCallBack.Bind(new Action(this.UseSkillRelease));
				ControllerBase<InputDistributeController>.Instance.BindAxis("WheelAxis", new TInputHandle<float>(this.OnInputWheelAxis));
				return;
			}
			UUIButtonComponent button2 = base.GetButton(17);
			button2.OnPointDownCallBack.Unbind();
			button2.OnPointUpCallBack.Unbind();
			button2.OnPointCancelCallBack.Unbind();
			ControllerBase<InputDistributeController>.Instance.UnBindAxis("WheelAxis", new TInputHandle<float>(this.OnInputWheelAxis));
		}

		// Token: 0x06036414 RID: 222228 RVA: 0x00DAC7C0 File Offset: 0x00DAA9C0
		protected override UniTask OnBeforeStartAsync()
		{
			BattleQuickHackView.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<BattleQuickHackView.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06036415 RID: 222229 RVA: 0x00DAC804 File Offset: 0x00DAAA04
		protected override void OnStart()
		{
			this.AutoUseSkillLongPressTime = ConfigCommonParamById.GetIntConfig("QuickHackAutoUseSkillLongPressTime").GetValueOrDefault();
			this.TryExitLongPressTime = ConfigCommonParamById.GetIntConfig("QuickHackTryExitLongPressTime").GetValueOrDefault();
			base.GetButton(18).RootUIComp.Get().SetUIActive(false);
			base.OnStart();
		}

		// Token: 0x06036416 RID: 222230 RVA: 0x00DAC864 File Offset: 0x00DAAA64
		protected override void OnBeforeShow()
		{
			base.OnBeforeShow();
			QuickHackTargetSelector targetSelector = ModelBase<QuickHackModel>.Instance.TargetSelector;
			IQuickHackLockTargetInfo quickHackLockTargetInfo = (targetSelector != null) ? targetSelector.GetLockTargetInfo() : null;
			this.HasLockOnTarget = (quickHackLockTargetInfo != null && quickHackLockTargetInfo.HackType != null);
			this.RefreshUseSkillLongPressMode(this.HasLockOnTarget);
		}

		// Token: 0x06036417 RID: 222231 RVA: 0x00DAC8B4 File Offset: 0x00DAAAB4
		protected override void OnTick(float delta)
		{
			base.OnTick(delta);
			BattleQuickHackLongPressItem useSkillLongPressItem = this.UseSkillLongPressItem;
			if (useSkillLongPressItem != null)
			{
				useSkillLongPressItem.Update(delta);
			}
			QuickHackTargetSelector targetSelector = ModelBase<QuickHackModel>.Instance.TargetSelector;
			IQuickHackLockTargetInfo quickHackLockTargetInfo = (targetSelector != null) ? targetSelector.GetLockTargetInfo() : null;
			bool flag = quickHackLockTargetInfo != null && quickHackLockTargetInfo.HackType != null;
			if (this.HasLockOnTarget != flag)
			{
				this.HasLockOnTarget = flag;
				this.RefreshUseSkillLongPressMode(flag);
			}
		}

		// Token: 0x06036418 RID: 222232 RVA: 0x00DAC91D File Offset: 0x00DAAB1D
		protected override bool ShouldShowTargetItem()
		{
			return false;
		}

		// Token: 0x06036419 RID: 222233 RVA: 0x00DAC920 File Offset: 0x00DAAB20
		protected override string GetSelectSkillAudioPath()
		{
			return "play_role_lucy_bat_burst01_qh_select";
		}

		// Token: 0x0603641A RID: 222234 RVA: 0x00DAC928 File Offset: 0x00DAAB28
		protected override List<UUIItem> GetSkillItems()
		{
			return new List<UUIItem>
			{
				base.GetItem(6),
				base.GetItem(30),
				base.GetItem(31),
				base.GetItem(32),
				base.GetItem(33),
				base.GetItem(34),
				base.GetItem(35)
			};
		}

		// Token: 0x0603641B RID: 222235 RVA: 0x00DAC99B File Offset: 0x00DAAB9B
		protected override string[] GetInputDistributeTags()
		{
			return new string[]
			{
				"FightInputRoot.FightInput.ActionInput",
				"FightInputRoot.FightInput.AxisInput.CameraInput.CameraRotation",
				"UiInputRoot.MouseInputTag",
				"UiInputRoot.Navigation"
			};
		}

		// Token: 0x0603641C RID: 222236 RVA: 0x00DAC9C3 File Offset: 0x00DAABC3
		protected override bool UseCurrentSkill()
		{
			bool flag = base.UseCurrentSkill();
			if (flag)
			{
				Singleton<AudioSystem>.Instance.PostEvent("play_role_lucy_bat_burst01_qh_scanning");
			}
			return flag;
		}

		// Token: 0x0603641D RID: 222237 RVA: 0x00DAC9DE File Offset: 0x00DAABDE
		private void OnInputWheelAxis(string name, float value, InputIdentification inputIdentification)
		{
			if (value != 0f)
			{
				Singleton<AudioSystem>.Instance.PostEvent("play_role_lucy_bat_burst01_qh_select");
				ControllerBase<QuickHackController>.Instance.SelectNextSkill(value < 0f, false);
			}
		}

		// Token: 0x0603641E RID: 222238 RVA: 0x00DACA0B File Offset: 0x00DAAC0B
		private void RefreshUseSkillLongPressMode(bool hasLockOnTarget)
		{
			BattleQuickHackLongPressItem useSkillLongPressItem = this.UseSkillLongPressItem;
			if (useSkillLongPressItem != null)
			{
				useSkillLongPressItem.SetActive(!hasLockOnTarget);
			}
			base.GetItem(28).SetUIActive(hasLockOnTarget);
			if (this.UseSkillLongPressTimer != null)
			{
				this.UseSkillLongPress();
			}
		}

		// Token: 0x0603641F RID: 222239 RVA: 0x00DACA3E File Offset: 0x00DAAC3E
		private void UseSkillPress()
		{
			if (!ControllerBase<QuickHackController>.Instance.CheckRamEnoughUseAnySkill())
			{
				ControllerBase<QuickHackController>.Instance.InteractFinish();
				return;
			}
			if (this.UseCurrentSkill())
			{
				ControllerBase<QuickHackController>.Instance.SelectNextSkill(true, true);
			}
			this.UseSkillLongPress();
		}

		// Token: 0x06036420 RID: 222240 RVA: 0x00DACA74 File Offset: 0x00DAAC74
		private void UseSkillLongPress()
		{
			BattleQuickHackLongPressItem useSkillLongPressItem = this.UseSkillLongPressItem;
			if (useSkillLongPressItem != null)
			{
				useSkillLongPressItem.StopLongPress();
			}
			TimerHandle useSkillLongPressTimer = this.UseSkillLongPressTimer;
			if (useSkillLongPressTimer != null)
			{
				useSkillLongPressTimer.Remove();
			}
			this.UseSkillLongPressTimer = null;
			if (this.HasLockOnTarget)
			{
				if (this.AutoUseSkillLongPressTime <= 0)
				{
					return;
				}
				this.UseSkillLongPressTimer = TimerSystem.GameplayTimeInstance.Forever(delegate(float _)
				{
					if (!ControllerBase<QuickHackController>.Instance.CheckAnySkillCanUse())
					{
						TimerHandle useSkillLongPressTimer2 = this.UseSkillLongPressTimer;
						if (useSkillLongPressTimer2 != null)
						{
							useSkillLongPressTimer2.Remove();
						}
						this.UseSkillLongPressTimer = null;
						ControllerBase<QuickHackController>.Instance.InteractFinish();
						return;
					}
					this.UseCurrentSkill();
					ControllerBase<QuickHackController>.Instance.SelectNextSkill(true, true);
				}, (float)this.AutoUseSkillLongPressTime, 1f, null, null, true);
				return;
			}
			else
			{
				if (this.TryExitLongPressTime <= 0)
				{
					return;
				}
				BattleQuickHackLongPressItem useSkillLongPressItem2 = this.UseSkillLongPressItem;
				if (useSkillLongPressItem2 != null)
				{
					useSkillLongPressItem2.StartLongPress((float)this.TryExitLongPressTime);
				}
				this.UseSkillLongPressTimer = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
				{
					this.UseSkillLongPressTimer = null;
					if (!ControllerBase<QuickHackController>.Instance.CheckAnySkillCanUse())
					{
						ControllerBase<QuickHackController>.Instance.InteractFinish();
					}
				}, (float)this.TryExitLongPressTime, null, null, true, 1f);
				return;
			}
		}

		// Token: 0x06036421 RID: 222241 RVA: 0x00DACB36 File Offset: 0x00DAAD36
		private void UseSkillRelease()
		{
			BattleQuickHackLongPressItem useSkillLongPressItem = this.UseSkillLongPressItem;
			if (useSkillLongPressItem != null)
			{
				useSkillLongPressItem.StopLongPress();
			}
			TimerHandle useSkillLongPressTimer = this.UseSkillLongPressTimer;
			if (useSkillLongPressTimer != null)
			{
				useSkillLongPressTimer.Remove();
			}
			this.UseSkillLongPressTimer = null;
		}

		// Token: 0x0401F308 RID: 127752
		[Nullable(2)]
		private BattleQuickHackLongPressItem UseSkillLongPressItem;

		// Token: 0x0401F309 RID: 127753
		private bool HasLockOnTarget;

		// Token: 0x0401F30A RID: 127754
		[Nullable(2)]
		private TimerHandle UseSkillLongPressTimer;

		// Token: 0x0401F30B RID: 127755
		private int AutoUseSkillLongPressTime;

		// Token: 0x0401F30C RID: 127756
		private int TryExitLongPressTime;

		// Token: 0x0200B237 RID: 45623
		[NullableContext(0)]
		private class EComponentType
		{
			// Token: 0x040373E4 RID: 226276
			public const int RamTitleText = 0;

			// Token: 0x040373E5 RID: 226277
			public const int RamBarLayout = 1;

			// Token: 0x040373E6 RID: 226278
			public const int RamItem = 2;

			// Token: 0x040373E7 RID: 226279
			public const int TipItem = 3;

			// Token: 0x040373E8 RID: 226280
			public const int TipText = 4;

			// Token: 0x040373E9 RID: 226281
			public const int SkillPanelLayout = 5;

			// Token: 0x040373EA RID: 226282
			public const int SkillItem = 6;

			// Token: 0x040373EB RID: 226283
			public const int InfoPanelItem = 7;

			// Token: 0x040373EC RID: 226284
			public const int InfoTitleText = 8;

			// Token: 0x040373ED RID: 226285
			public const int InfoTagBgSprite = 9;

			// Token: 0x040373EE RID: 226286
			public const int InfoTagText = 10;

			// Token: 0x040373EF RID: 226287
			public const int InfoDurationText = 11;

			// Token: 0x040373F0 RID: 226288
			public const int InfoUploadText = 12;

			// Token: 0x040373F1 RID: 226289
			public const int InfoDescText = 13;

			// Token: 0x040373F2 RID: 226290
			public const int DurationLimitItem = 14;

			// Token: 0x040373F3 RID: 226291
			public const int DurationLimitText = 15;

			// Token: 0x040373F4 RID: 226292
			public const int DurationLimitBarSprite = 16;

			// Token: 0x040373F5 RID: 226293
			public const int UseSkillButton = 17;

			// Token: 0x040373F6 RID: 226294
			public const int FinishButton = 18;

			// Token: 0x040373F7 RID: 226295
			public const int UnlockItem = 19;

			// Token: 0x040373F8 RID: 226296
			public const int LockItem = 20;

			// Token: 0x040373F9 RID: 226297
			public const int TargetItem = 21;

			// Token: 0x040373FA RID: 226298
			public const int RamSpriteDarkBlue = 22;

			// Token: 0x040373FB RID: 226299
			public const int RamSpriteBlue = 23;

			// Token: 0x040373FC RID: 226300
			public const int RamSpriteRedA = 24;

			// Token: 0x040373FD RID: 226301
			public const int RamSpriteRedB = 25;

			// Token: 0x040373FE RID: 226302
			public const int UseSkillLongPressItem = 26;

			// Token: 0x040373FF RID: 226303
			public const int UseSkillKeyItem = 27;

			// Token: 0x04037400 RID: 226304
			public const int UseSkillNiagaraItem = 28;

			// Token: 0x04037401 RID: 226305
			public const int InfoLineItem = 29;

			// Token: 0x04037402 RID: 226306
			public const int SkillItem2 = 30;

			// Token: 0x04037403 RID: 226307
			public const int SkillItem3 = 31;

			// Token: 0x04037404 RID: 226308
			public const int SkillItem4 = 32;

			// Token: 0x04037405 RID: 226309
			public const int SkillItem5 = 33;

			// Token: 0x04037406 RID: 226310
			public const int SkillItem6 = 34;

			// Token: 0x04037407 RID: 226311
			public const int SkillItem7 = 35;
		}
	}
}
