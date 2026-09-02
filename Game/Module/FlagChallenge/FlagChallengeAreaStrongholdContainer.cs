using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.FlagChallenge
{
	// Token: 0x02005D4D RID: 23885
	[NullableContext(1)]
	[Nullable(0)]
	public class FlagChallengeAreaStrongholdContainer : UiPanelBase
	{
		// Token: 0x0603C359 RID: 246617 RVA: 0x00F456CE File Offset: 0x00F438CE
		public FlagChallengeAreaStrongholdContainer(int activityId, int levelId, int areaId)
		{
			this.ActivityId = activityId;
			this.LevelId = levelId;
			this.AreaId = areaId;
		}

		// Token: 0x0603C35A RID: 246618 RVA: 0x00F456F6 File Offset: 0x00F438F6
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUITexture)),
				new ValueTuple<int, Type>(1, typeof(UUIItem))
			};
		}

		// Token: 0x0603C35B RID: 246619 RVA: 0x00F45730 File Offset: 0x00F43930
		protected override UniTask OnBeforeStartAsync()
		{
			FlagChallengeAreaStrongholdContainer.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<FlagChallengeAreaStrongholdContainer.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603C35C RID: 246620 RVA: 0x00F45774 File Offset: 0x00F43974
		protected override void OnStart()
		{
			EFlagChallengeUiStyleType uiStyle = (EFlagChallengeUiStyleType)ConfigBase<FlagChallengeConfig>.Instance.GetLevelConfig(this.LevelId).Value.UiStyle;
			int uiPos = ConfigBase<FlagChallengeConfig>.Instance.GetAreaConfig(this.AreaId).Value.UiPos;
			string dynamicRes = FlagChallengeUtils.GetDynamicRes(uiStyle, "AreaDetailItemBg", uiPos);
			UUITexture bgTex = base.GetTexture(0);
			base.SetTextureByPath(ConfigBase<UiResourceConfig>.Instance.GetResourcePath(dynamicRes), bgTex, null, delegate(bool _)
			{
				bgTex.SetSizeFromTexture();
			});
		}

		// Token: 0x0603C35D RID: 246621 RVA: 0x00F45814 File Offset: 0x00F43A14
		private UniTask CreateStrongholdItemAsync(FlagChallengeStrongholdData data)
		{
			FlagChallengeAreaStrongholdContainer.<CreateStrongholdItemAsync>d__10 <CreateStrongholdItemAsync>d__;
			<CreateStrongholdItemAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateStrongholdItemAsync>d__.<>4__this = this;
			<CreateStrongholdItemAsync>d__.data = data;
			<CreateStrongholdItemAsync>d__.<>1__state = -1;
			<CreateStrongholdItemAsync>d__.<>t__builder.Start<FlagChallengeAreaStrongholdContainer.<CreateStrongholdItemAsync>d__10>(ref <CreateStrongholdItemAsync>d__);
			return <CreateStrongholdItemAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603C35E RID: 246622 RVA: 0x00F4585F File Offset: 0x00F43A5F
		public void SetItemSelectChangeCallback(Action<int> callback)
		{
			this.ItemSelectChangeCallback = callback;
		}

		// Token: 0x0603C35F RID: 246623 RVA: 0x00F45868 File Offset: 0x00F43A68
		public void SetItemSelect(int id)
		{
			FlagChallengeAreaStrongholdItem flagChallengeAreaStrongholdItem;
			if (this.StrongholdItemMap.TryGetValue(id, out flagChallengeAreaStrongholdItem) && flagChallengeAreaStrongholdItem != null)
			{
				flagChallengeAreaStrongholdItem.SetSelected(true, true);
			}
		}

		// Token: 0x0603C360 RID: 246624 RVA: 0x00F45890 File Offset: 0x00F43A90
		private void OnItemToggleCallback(int id)
		{
			if (this.SelectedStrongholdId != null)
			{
				int? selectedStrongholdId = this.SelectedStrongholdId;
				FlagChallengeAreaStrongholdItem flagChallengeAreaStrongholdItem;
				if (!(selectedStrongholdId.GetValueOrDefault() == id & selectedStrongholdId != null) && this.StrongholdItemMap.TryGetValue(this.SelectedStrongholdId.Value, out flagChallengeAreaStrongholdItem))
				{
					flagChallengeAreaStrongholdItem.SetSelected(false, false);
				}
			}
			this.SelectedStrongholdId = new int?(id);
			Action<int> itemSelectChangeCallback = this.ItemSelectChangeCallback;
			if (itemSelectChangeCallback == null)
			{
				return;
			}
			itemSelectChangeCallback(id);
		}

		// Token: 0x0603C361 RID: 246625 RVA: 0x00F45908 File Offset: 0x00F43B08
		[NullableContext(2)]
		public FlagChallengeAreaStrongholdItem GetBossStrongholdItem()
		{
			foreach (FlagChallengeAreaStrongholdItem flagChallengeAreaStrongholdItem in this.StrongholdItemMap.Values)
			{
				if (flagChallengeAreaStrongholdItem.GetIsBoss())
				{
					return flagChallengeAreaStrongholdItem;
				}
			}
			return null;
		}

		// Token: 0x04021CFF RID: 138495
		private readonly int ActivityId;

		// Token: 0x04021D00 RID: 138496
		private readonly int LevelId;

		// Token: 0x04021D01 RID: 138497
		private readonly int AreaId;

		// Token: 0x04021D02 RID: 138498
		private readonly Dictionary<int, FlagChallengeAreaStrongholdItem> StrongholdItemMap = new Dictionary<int, FlagChallengeAreaStrongholdItem>();

		// Token: 0x04021D03 RID: 138499
		[Nullable(2)]
		private Action<int> ItemSelectChangeCallback;

		// Token: 0x04021D04 RID: 138500
		private int? SelectedStrongholdId;
	}
}
