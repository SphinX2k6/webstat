using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Activity.ActivityContent.Mowing;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.InstanceDungeon
{
	// Token: 0x02005BD2 RID: 23506
	[NullableContext(1)]
	[Nullable(0)]
	public class MowingDifficultyDropDownPanel : UiPanelBase
	{
		// Token: 0x0603B83B RID: 243771 RVA: 0x00F16B68 File Offset: 0x00F14D68
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
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
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>();
		}

		// Token: 0x0603B83C RID: 243772 RVA: 0x00F16C20 File Offset: 0x00F14E20
		protected override UniTask OnBeforeStartAsync()
		{
			MowingDifficultyDropDownPanel.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MowingDifficultyDropDownPanel.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603B83D RID: 243773 RVA: 0x00F16C64 File Offset: 0x00F14E64
		private UniTask CreateDropDownCom()
		{
			MowingDifficultyDropDownPanel.<CreateDropDownCom>d__6 <CreateDropDownCom>d__;
			<CreateDropDownCom>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateDropDownCom>d__.<>4__this = this;
			<CreateDropDownCom>d__.<>1__state = -1;
			<CreateDropDownCom>d__.<>t__builder.Start<MowingDifficultyDropDownPanel.<CreateDropDownCom>d__6>(ref <CreateDropDownCom>d__);
			return <CreateDropDownCom>d__.<>t__builder.Task;
		}

		// Token: 0x0603B83E RID: 243774 RVA: 0x00F16CA7 File Offset: 0x00F14EA7
		protected override void OnStart()
		{
			base.GetItem(1).SetUIActive(false);
		}

		// Token: 0x0603B83F RID: 243775 RVA: 0x00F16CB6 File Offset: 0x00F14EB6
		private DropDownItem OnCreateDropDownItem(UUIItem item, TakeWeedsDifficulty data)
		{
			return new DropDownItem(item);
		}

		// Token: 0x0603B840 RID: 243776 RVA: 0x00F16CBE File Offset: 0x00F14EBE
		private DropDownTitle OnCreateDropDownTitle(UUIItem item)
		{
			return new DropDownTitle(item);
		}

		// Token: 0x0603B841 RID: 243777 RVA: 0x00F16CC8 File Offset: 0x00F14EC8
		private unsafe IReadOnlyList<TakeWeedsDifficulty> GetDifficultyDataList()
		{
			KillMonstersScores? config = ConfigKillMonstersScoresByInstanceID.GetConfig(this.InstanceId.Value, true);
			if (config == null || config.Value.DifficultyOptionsLength == 0)
			{
				return Array.Empty<TakeWeedsDifficulty>();
			}
			List<TakeWeedsDifficulty> list = new List<TakeWeedsDifficulty>();
			Span<int> difficultyOptionsBytes = config.Value.GetDifficultyOptionsBytes();
			for (int i = 0; i < difficultyOptionsBytes.Length; i++)
			{
				TakeWeedsDifficulty? config2 = ConfigTakeWeedsDifficultyById.GetConfig(*difficultyOptionsBytes[i], true);
				if (config2 != null)
				{
					list.Add(config2.Value);
				}
			}
			return list;
		}

		// Token: 0x0603B842 RID: 243778 RVA: 0x00F16D5C File Offset: 0x00F14F5C
		private TakeWeedsDifficulty GetDropDownItemData(TakeWeedsDifficulty data)
		{
			return data;
		}

		// Token: 0x0603B843 RID: 243779 RVA: 0x00F16D60 File Offset: 0x00F14F60
		public void RefreshByInstanceId(int id)
		{
			this.InstanceId = new int?(id);
			this.LevelData = ConfigKillMonstersScoresByInstanceID.GetConfig(this.InstanceId.Value, true);
			ActivityMowingData mowingActivityData = ControllerBase<ActivityMowingController>.Instance.GetMowingActivityData();
			if (mowingActivityData == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Activity, ELogAuthor.YYZ, "当前没有割草活动数据", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			CommonDropDown<TakeWeedsDifficulty, TakeWeedsDifficulty> difficultyDropDown = this.DifficultyDropDown;
			if (difficultyDropDown == null)
			{
				return;
			}
			difficultyDropDown.InitScroll(this.GetDifficultyDataList(), new Func<TakeWeedsDifficulty, TakeWeedsDifficulty>(this.GetDropDownItemData), mowingActivityData.GetLevelDiffIndex(this.InstanceId.Value), true);
		}

		// Token: 0x0603B844 RID: 243780 RVA: 0x00F16DF4 File Offset: 0x00F14FF4
		private void OnSelectDifficulty(int index, TakeWeedsDifficulty data)
		{
			ActivityMowingData mowingActivityData = ControllerBase<ActivityMowingController>.Instance.GetMowingActivityData();
			TakeWeedsDifficulty takeWeedsDifficulty = data;
			if (mowingActivityData == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Activity, ELogAuthor.YYZ, "当前没有割草活动数据", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if (this.LevelData == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Activity, ELogAuthor.YYZ, "当前没有割草活动副本数据", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			string item = ConfigTakeWeedsDifficultyById.GetConfig(takeWeedsDifficulty.Id, true).Value.RecommendedLevel.ToString();
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), "RecommendLevel", new <>z__ReadOnlySingleElementList<object>(item));
			ControllerBase<ActivityMowingController>.Instance.RequestSetDifficultyAll(mowingActivityData.Id, takeWeedsDifficulty.Id);
		}

		// Token: 0x0402184A RID: 137290
		[Nullable(2)]
		private CommonDropDown<TakeWeedsDifficulty, TakeWeedsDifficulty> DifficultyDropDown;

		// Token: 0x0402184B RID: 137291
		private int? InstanceId;

		// Token: 0x0402184C RID: 137292
		private KillMonstersScores? LevelData;

		// Token: 0x0200BC3C RID: 48188
		[NullableContext(0)]
		private static class EDropDownPanelComponents
		{
			// Token: 0x0403A0E9 RID: 237801
			public const int TxtTitle = 0;

			// Token: 0x0403A0EA RID: 237802
			public const int PanelTitle = 1;

			// Token: 0x0403A0EB RID: 237803
			public const int DropdownItem = 2;

			// Token: 0x0403A0EC RID: 237804
			public const int TxtTips = 3;
		}
	}
}
