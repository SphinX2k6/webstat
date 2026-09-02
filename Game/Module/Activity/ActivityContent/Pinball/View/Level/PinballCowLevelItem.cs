using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Level
{
	// Token: 0x02006600 RID: 26112
	public class PinballCowLevelItem : UiPanelBase
	{
		// Token: 0x060413FE RID: 267262 RVA: 0x010BD020 File Offset: 0x010BB220
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(delegate(EToggleState _)
			{
				this.OnTogClick();
			}));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060413FF RID: 267263 RVA: 0x010BD108 File Offset: 0x010BB308
		private bool IsLevelLock(int levelId)
		{
			return ModelBase<PinballModel>.Instance.ActivityData.GetLevelLockStatus(levelId) != EPinballChapterLevelLockStatus.Activated;
		}

		// Token: 0x06041400 RID: 267264 RVA: 0x010BD120 File Offset: 0x010BB320
		[NullableContext(1)]
		private string GetLevelLockTexts(int levelId)
		{
			return ModelBase<PinballModel>.Instance.ActivityData.GetLevelPreConditionLockTexts(levelId);
		}

		// Token: 0x06041401 RID: 267265 RVA: 0x010BD134 File Offset: 0x010BB334
		[NullableContext(1)]
		public void Refresh(PinballLevelRecordData data)
		{
			this.Data = data;
			PinballLevelConfig? pinballLevelConfigById = ConfigBase<PinballConfig>.Instance.GetPinballLevelConfigById(data.LevelId);
			bool uiactive = this.IsLevelLock(data.LevelId);
			bool uiactive2 = data.PassStatus == EPinballLevelPassStatus.Perfect;
			base.GetItem(1).SetUIActive(uiactive);
			base.GetItem(3).SetUIActive(uiactive2);
			base.SetTextureByPath(pinballLevelConfigById.Value.Icon, base.GetTexture(2), null, null);
		}

		// Token: 0x06041402 RID: 267266 RVA: 0x010BD1B1 File Offset: 0x010BB3B1
		public void SelectLevel()
		{
			this.OnTogClick();
		}

		// Token: 0x06041403 RID: 267267 RVA: 0x010BD1BC File Offset: 0x010BB3BC
		private void OnTogClick()
		{
			if (this.Data == null)
			{
				return;
			}
			PinballLevelInfoData arg = new PinballLevelInfoData
			{
				LevelId = this.Data.LevelId,
				RealLevelId = this.Data.LevelId,
				LevelLock = new bool?(this.IsLevelLock(this.Data.LevelId)),
				LevelLockTexts = this.GetLevelLockTexts(this.Data.LevelId),
				LevelScore = new int?(this.Data.LevelScore),
				ShowScore = new bool?(true),
				ShowDesc = new bool?(true)
			};
			Action<PinballLevelRecordData, IPinballLevelInfoData, UUIExtendToggle> onTogLevelClick = this.OnTogLevelClick;
			if (onTogLevelClick == null)
			{
				return;
			}
			onTogLevelClick(this.Data, arg, base.GetExtendToggle(0));
		}

		// Token: 0x04024869 RID: 149609
		[Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})]
		public Action<PinballLevelRecordData, IPinballLevelInfoData, UUIExtendToggle> OnTogLevelClick;

		// Token: 0x0402486A RID: 149610
		[Nullable(2)]
		private PinballLevelRecordData Data;

		// Token: 0x0200C61C RID: 50716
		private enum EComponent
		{
			// Token: 0x0403CFAE RID: 249774
			TogItem,
			// Token: 0x0403CFAF RID: 249775
			LockItem,
			// Token: 0x0403CFB0 RID: 249776
			SprIcon,
			// Token: 0x0403CFB1 RID: 249777
			FinishedItem
		}
	}
}
