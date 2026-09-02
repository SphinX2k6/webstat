using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Level
{
	// Token: 0x02006605 RID: 26117
	[NullableContext(1)]
	[Nullable(0)]
	public class PinballLevelItem : UiPanelBase
	{
		// Token: 0x06041426 RID: 267302 RVA: 0x010BE27C File Offset: 0x010BC47C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
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

		// Token: 0x06041427 RID: 267303 RVA: 0x010BE385 File Offset: 0x010BC585
		protected override void OnStart()
		{
			this.StarLayout = new GenericLayout<PinballLevelStarItem, IPinballLevelStarData>(base.GetHorizontalLayout(1), new Func<PinballLevelStarItem>(this.InitStarItem), null, false, true);
		}

		// Token: 0x06041428 RID: 267304 RVA: 0x010BE3A8 File Offset: 0x010BC5A8
		private PinballLevelStarItem InitStarItem()
		{
			return new PinballLevelStarItem();
		}

		// Token: 0x06041429 RID: 267305 RVA: 0x010BE3AF File Offset: 0x010BC5AF
		private bool IsLevelLock(int levelId)
		{
			return ModelBase<PinballModel>.Instance.ActivityData.GetLevelLockStatus(levelId) != EPinballChapterLevelLockStatus.Activated;
		}

		// Token: 0x0604142A RID: 267306 RVA: 0x010BE3C7 File Offset: 0x010BC5C7
		private string GetLevelLockTexts(int levelId)
		{
			return ModelBase<PinballModel>.Instance.ActivityData.GetLevelPreConditionLockTexts(levelId);
		}

		// Token: 0x0604142B RID: 267307 RVA: 0x010BE3DC File Offset: 0x010BC5DC
		public void Refresh(PinballLevelRecordData data)
		{
			this.Data = data;
			PinballLevelConfig? pinballLevelConfigById = ConfigBase<PinballConfig>.Instance.GetPinballLevelConfigById(data.LevelId);
			int starCondLength = pinballLevelConfigById.Value.StarCondLength;
			List<IPinballLevelStarData> list = new List<IPinballLevelStarData>();
			for (int i = 0; i < starCondLength; i++)
			{
				int num = pinballLevelConfigById.Value.StarCond(i);
				bool passed = Array.IndexOf<int>(data.LevelStarConditionIds, num) >= 0;
				PinballLevelStarData item = new PinballLevelStarData
				{
					ConditionId = num,
					Passed = passed
				};
				list.Add(item);
			}
			this.StarLayout.RefreshByData(list, null, false);
			bool flag = this.IsLevelLock(data.LevelId);
			base.GetItem(3).SetUIActive(flag);
			base.GetItem(4).SetUIActive(!flag);
		}

		// Token: 0x0604142C RID: 267308 RVA: 0x010BE4A8 File Offset: 0x010BC6A8
		public void SelectLevel()
		{
			this.OnTogClick();
		}

		// Token: 0x0604142D RID: 267309 RVA: 0x010BE4B0 File Offset: 0x010BC6B0
		private void OnTogClick()
		{
			if (this.Data == null)
			{
				return;
			}
			bool value = this.IsLevelLock(this.Data.LevelId);
			string levelLockTexts = this.GetLevelLockTexts(this.Data.LevelId);
			PinballLevelInfoData arg = new PinballLevelInfoData
			{
				LevelId = this.Data.LevelId,
				RealLevelId = this.Data.LevelId,
				LevelStarConditionIds = this.Data.LevelStarConditionIds,
				LevelLock = new bool?(value),
				LevelLockTexts = levelLockTexts,
				ShowStar = new bool?(true),
				ShowReward = new bool?(true),
				RewardReceived = new bool?(this.Data.LevelStarConditionIds.Length != 0)
			};
			Action<PinballLevelRecordData, IPinballLevelInfoData, UUIExtendToggle> onTogLevelClick = this.OnTogLevelClick;
			if (onTogLevelClick == null)
			{
				return;
			}
			onTogLevelClick(this.Data, arg, base.GetExtendToggle(0));
		}

		// Token: 0x04024873 RID: 149619
		[Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})]
		public Action<PinballLevelRecordData, IPinballLevelInfoData, UUIExtendToggle> OnTogLevelClick;

		// Token: 0x04024874 RID: 149620
		[Nullable(2)]
		private PinballLevelRecordData Data;

		// Token: 0x04024875 RID: 149621
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<PinballLevelStarItem, IPinballLevelStarData> StarLayout;

		// Token: 0x0200C627 RID: 50727
		[NullableContext(0)]
		private enum EComponent
		{
			// Token: 0x0403CFEF RID: 249839
			TogItem,
			// Token: 0x0403CFF0 RID: 249840
			StarLayout,
			// Token: 0x0403CFF1 RID: 249841
			StarItem,
			// Token: 0x0403CFF2 RID: 249842
			LockItem,
			// Token: 0x0403CFF3 RID: 249843
			NumItem
		}
	}
}
