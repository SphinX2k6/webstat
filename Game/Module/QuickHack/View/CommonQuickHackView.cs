using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.QuickHack.View
{
	// Token: 0x02005306 RID: 21254
	[NullableContext(1)]
	[Nullable(0)]
	public class CommonQuickHackView : QuickHackViewBase
	{
		// Token: 0x06036425 RID: 222245 RVA: 0x00DACBDB File Offset: 0x00DAADDB
		public CommonQuickHackView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06036426 RID: 222246 RVA: 0x00DACBE4 File Offset: 0x00DAADE4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 33;
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
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(19, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(20, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(21, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(22, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(23, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(24, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(25, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(26, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(27, typeof(UUISprite));
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
			this.ComponentRegisterInfos = list;
			num2 = 4;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(14, new Action(this.OnUseSkillClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(15, new Action(this.OnFinishClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(16, new Action(this.OnLeftClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(17, new Action(this.OnRightClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06036427 RID: 222247 RVA: 0x00DAD110 File Offset: 0x00DAB310
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
				return 21;
			case EQuickHackUiType.DurationLimitBarSprite:
				return 23;
			case EQuickHackUiType.DurationLimitText:
				return 22;
			case EQuickHackUiType.TargetItem:
				return 20;
			case EQuickHackUiType.RamSpriteDarkBlue:
				return 24;
			case EQuickHackUiType.RamSpriteBlue:
				return 25;
			case EQuickHackUiType.RamSpriteRedA:
				return 26;
			case EQuickHackUiType.RamSpriteRedB:
				return 27;
			case EQuickHackUiType.UseSkillKeyItem:
				return 28;
			case EQuickHackUiType.InfoLineItem:
				return 29;
			default:
				return -1;
			}
		}

		// Token: 0x06036428 RID: 222248 RVA: 0x00DAD1AC File Offset: 0x00DAB3AC
		protected override void RefreshInput(bool enable)
		{
			if (enable)
			{
				ControllerBase<InputDistributeController>.Instance.BindAxis("WheelAxis", new TInputHandle<float>(this.OnInputWheelAxis));
				return;
			}
			ControllerBase<InputDistributeController>.Instance.UnBindAxis("WheelAxis", new TInputHandle<float>(this.OnInputWheelAxis));
		}

		// Token: 0x06036429 RID: 222249 RVA: 0x00DAD1E8 File Offset: 0x00DAB3E8
		protected override void OnUpdateCurrentSkillCanUse(bool canUse)
		{
			base.GetButton(14).SetSelfInteractive(canUse);
		}

		// Token: 0x0603642A RID: 222250 RVA: 0x00DAD1F8 File Offset: 0x00DAB3F8
		protected override string GetSelectSkillAudioPath()
		{
			return "play_ui_focus_mode_scanning_choice";
		}

		// Token: 0x0603642B RID: 222251 RVA: 0x00DAD1FF File Offset: 0x00DAB3FF
		protected override List<UUIItem> GetSkillItems()
		{
			return new List<UUIItem>
			{
				base.GetItem(6),
				base.GetItem(30),
				base.GetItem(31),
				base.GetItem(32)
			};
		}

		// Token: 0x0603642C RID: 222252 RVA: 0x00DAD23D File Offset: 0x00DAB43D
		private void OnUseSkillClick()
		{
			this.UseCurrentSkill();
			if (!ControllerBase<QuickHackController>.Instance.CheckRamEnoughUseAnySkill())
			{
				ControllerBase<QuickHackController>.Instance.InteractFinish();
			}
		}

		// Token: 0x0603642D RID: 222253 RVA: 0x00DAD25C File Offset: 0x00DAB45C
		private void OnFinishClick()
		{
			ControllerBase<QuickHackController>.Instance.InteractFinish();
		}

		// Token: 0x0603642E RID: 222254 RVA: 0x00DAD268 File Offset: 0x00DAB468
		private void OnLeftClick()
		{
			ControllerBase<QuickHackController>.Instance.LookAtNextEnableLockTarget(true);
		}

		// Token: 0x0603642F RID: 222255 RVA: 0x00DAD275 File Offset: 0x00DAB475
		private void OnRightClick()
		{
			ControllerBase<QuickHackController>.Instance.LookAtNextEnableLockTarget(false);
		}

		// Token: 0x06036430 RID: 222256 RVA: 0x00DAD284 File Offset: 0x00DAB484
		private void OnInputWheelAxis(string name, float value, InputIdentification inputIdentification)
		{
			if (value == 0f)
			{
				return;
			}
			List<QuickHackSkillInstance> currentSkillList = ModelBase<QuickHackModel>.Instance.CurrentSkillList;
			if (currentSkillList == null || currentSkillList.Count == 0)
			{
				return;
			}
			Singleton<AudioSystem>.Instance.PostEvent("play_ui_focus_mode_scanning_choice");
			ControllerBase<QuickHackController>.Instance.SelectNextSkill(value < 0f, false);
		}

		// Token: 0x0200B239 RID: 45625
		[NullableContext(0)]
		private class EComponentType
		{
			// Token: 0x0403740C RID: 226316
			public const int RamTitleText = 0;

			// Token: 0x0403740D RID: 226317
			public const int RamBarLayout = 1;

			// Token: 0x0403740E RID: 226318
			public const int RamItem = 2;

			// Token: 0x0403740F RID: 226319
			public const int TipItem = 3;

			// Token: 0x04037410 RID: 226320
			public const int TipText = 4;

			// Token: 0x04037411 RID: 226321
			public const int SkillPanelLayout = 5;

			// Token: 0x04037412 RID: 226322
			public const int SkillItem = 6;

			// Token: 0x04037413 RID: 226323
			public const int InfoPanelItem = 7;

			// Token: 0x04037414 RID: 226324
			public const int InfoTitleText = 8;

			// Token: 0x04037415 RID: 226325
			public const int InfoTagBgSprite = 9;

			// Token: 0x04037416 RID: 226326
			public const int InfoTagText = 10;

			// Token: 0x04037417 RID: 226327
			public const int InfoDurationText = 11;

			// Token: 0x04037418 RID: 226328
			public const int InfoUploadText = 12;

			// Token: 0x04037419 RID: 226329
			public const int InfoDescText = 13;

			// Token: 0x0403741A RID: 226330
			public const int UseSkillButton = 14;

			// Token: 0x0403741B RID: 226331
			public const int FinishButton = 15;

			// Token: 0x0403741C RID: 226332
			public const int LeftButton = 16;

			// Token: 0x0403741D RID: 226333
			public const int RightButton = 17;

			// Token: 0x0403741E RID: 226334
			public const int UnlockItem = 18;

			// Token: 0x0403741F RID: 226335
			public const int LockItem = 19;

			// Token: 0x04037420 RID: 226336
			public const int TargetItem = 20;

			// Token: 0x04037421 RID: 226337
			public const int DurationLimitItem = 21;

			// Token: 0x04037422 RID: 226338
			public const int DurationLimitText = 22;

			// Token: 0x04037423 RID: 226339
			public const int DurationLimitBarSprite = 23;

			// Token: 0x04037424 RID: 226340
			public const int RamSpriteDarkBlue = 24;

			// Token: 0x04037425 RID: 226341
			public const int RamSpriteBlue = 25;

			// Token: 0x04037426 RID: 226342
			public const int RamSpriteRedA = 26;

			// Token: 0x04037427 RID: 226343
			public const int RamSpriteRedB = 27;

			// Token: 0x04037428 RID: 226344
			public const int UseSkillKeyItem = 28;

			// Token: 0x04037429 RID: 226345
			public const int InfoLineItem = 29;

			// Token: 0x0403742A RID: 226346
			public const int SkillItem2 = 30;

			// Token: 0x0403742B RID: 226347
			public const int SkillItem3 = 31;

			// Token: 0x0403742C RID: 226348
			public const int SkillItem4 = 32;
		}
	}
}
