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

namespace CSharpScript.Game.Module.InstanceDungeon.InstanceDungeonSubComponent
{
	// Token: 0x02005BEA RID: 23530
	[NullableContext(1)]
	[Nullable(0)]
	public class InstanceDungeonMowingDropDownItem : UiPanelBase
	{
		// Token: 0x0603B8FF RID: 243967 RVA: 0x00F195E8 File Offset: 0x00F177E8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>();
		}

		// Token: 0x0603B900 RID: 243968 RVA: 0x00F1963C File Offset: 0x00F1783C
		protected override UniTask OnBeforeStartAsync()
		{
			InstanceDungeonMowingDropDownItem.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<InstanceDungeonMowingDropDownItem.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603B901 RID: 243969 RVA: 0x00F19680 File Offset: 0x00F17880
		private UniTask CreateDropDownCom()
		{
			InstanceDungeonMowingDropDownItem.<CreateDropDownCom>d__8 <CreateDropDownCom>d__;
			<CreateDropDownCom>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateDropDownCom>d__.<>4__this = this;
			<CreateDropDownCom>d__.<>1__state = -1;
			<CreateDropDownCom>d__.<>t__builder.Start<InstanceDungeonMowingDropDownItem.<CreateDropDownCom>d__8>(ref <CreateDropDownCom>d__);
			return <CreateDropDownCom>d__.<>t__builder.Task;
		}

		// Token: 0x0603B902 RID: 243970 RVA: 0x00F196C3 File Offset: 0x00F178C3
		protected override void OnStart()
		{
			base.AddChild(this.DifficultyDropDown);
			if (this.ItemDataHandle != null)
			{
				this.RefreshItem(this.ItemDataHandle.InstanceId);
			}
		}

		// Token: 0x0603B903 RID: 243971 RVA: 0x00F196EA File Offset: 0x00F178EA
		private DropDownItem OnCreateDropDownItem(UUIItem item, TakeWeedsDifficulty data)
		{
			return new DropDownItem(item);
		}

		// Token: 0x0603B904 RID: 243972 RVA: 0x00F196F2 File Offset: 0x00F178F2
		private DropDownTitle OnCreateDropDownTitle(UUIItem item)
		{
			return new DropDownTitle(item);
		}

		// Token: 0x0603B905 RID: 243973 RVA: 0x00F196FC File Offset: 0x00F178FC
		private TakeWeedsDifficulty[] GetDifficultyDataList()
		{
			KillMonstersScores? config = ConfigKillMonstersScoresByInstanceID.GetConfig(this.InstanceId.Value, true);
			if (config == null || config.Value.DifficultyOptionsLength == 0)
			{
				return this.EmptyArray;
			}
			List<TakeWeedsDifficulty> list = new List<TakeWeedsDifficulty>();
			int[] array = config.Value.DifficultyOptions();
			for (int i = 0; i < array.Length; i++)
			{
				TakeWeedsDifficulty? config2 = ConfigTakeWeedsDifficultyById.GetConfig(array[i], true);
				if (config2 != null)
				{
					list.Add(config2.Value);
				}
			}
			return list.ToArray();
		}

		// Token: 0x0603B906 RID: 243974 RVA: 0x00F1978C File Offset: 0x00F1798C
		private TakeWeedsDifficulty GetDropDownItemData(TakeWeedsDifficulty data)
		{
			return data;
		}

		// Token: 0x0603B907 RID: 243975 RVA: 0x00F19790 File Offset: 0x00F17990
		public void RefreshItem(int instanceId)
		{
			if (base.InAsyncLoading())
			{
				this.ItemDataHandle = new InstanceDungeonMowingDropDownItemData
				{
					InstanceId = instanceId
				};
				return;
			}
			this.InstanceId = new int?(instanceId);
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

		// Token: 0x0603B908 RID: 243976 RVA: 0x00F19840 File Offset: 0x00F17A40
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
			ControllerBase<ActivityMowingController>.Instance.RequestSetDifficultyAll(mowingActivityData.Id, takeWeedsDifficulty.Id);
		}

		// Token: 0x04021885 RID: 137349
		[Nullable(2)]
		private InstanceDungeonMowingDropDownItemData ItemDataHandle;

		// Token: 0x04021886 RID: 137350
		private int? InstanceId;

		// Token: 0x04021887 RID: 137351
		private readonly TakeWeedsDifficulty[] EmptyArray = Array.Empty<TakeWeedsDifficulty>();

		// Token: 0x04021888 RID: 137352
		[Nullable(2)]
		private CommonDropDown<TakeWeedsDifficulty, TakeWeedsDifficulty> DifficultyDropDown;

		// Token: 0x04021889 RID: 137353
		private KillMonstersScores? LevelData;

		// Token: 0x0200BC61 RID: 48225
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403A16B RID: 237931
			DropdownItem
		}
	}
}
