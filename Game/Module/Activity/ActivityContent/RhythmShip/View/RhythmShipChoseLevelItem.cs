using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RhythmShip.View
{
	// Token: 0x020064DE RID: 25822
	[NullableContext(1)]
	[Nullable(0)]
	internal class RhythmShipChoseLevelItem : UiPanelBase
	{
		// Token: 0x06040B01 RID: 264961 RVA: 0x01095BD0 File Offset: 0x01093DD0
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(1, typeof(UUITexture)),
				new ValueTuple<int, Type>(2, typeof(UUITexture)),
				new ValueTuple<int, Type>(3, typeof(UUIText)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUIItem)),
				new ValueTuple<int, Type>(9, typeof(UUIItem)),
				new ValueTuple<int, Type>(10, typeof(UUIItem)),
				new ValueTuple<int, Type>(11, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle))
			};
		}

		// Token: 0x06040B02 RID: 264962 RVA: 0x01095D16 File Offset: 0x01093F16
		protected override void OnStart()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnRhythmShipRedDotRefresh, new Action<List<int>, List<int>, List<int>>(this.OnRhythmShipRedDotRefresh));
		}

		// Token: 0x06040B03 RID: 264963 RVA: 0x01095D34 File Offset: 0x01093F34
		protected override void OnBeforeDestroy()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnRhythmShipRedDotRefresh, new Action<List<int>, List<int>, List<int>>(this.OnRhythmShipRedDotRefresh));
		}

		// Token: 0x06040B04 RID: 264964 RVA: 0x01095D54 File Offset: 0x01093F54
		protected override UniTask OnBeforeStartAsync()
		{
			RhythmShipChoseLevelItem.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RhythmShipChoseLevelItem.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06040B05 RID: 264965 RVA: 0x01095D98 File Offset: 0x01093F98
		private void OnToggleUndeterminedClicked()
		{
			RhythmShipLevel? rhythmShipLevelById = ConfigBase<RhythmShipConfig>.Instance.GetRhythmShipLevelById(this.LevelId);
			if (rhythmShipLevelById == null)
			{
				return;
			}
			if (!ModelBase<RhythmShipModel>.Instance.GetPlanetLevelUnlock(rhythmShipLevelById.Value.Planet))
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByText(ModelBase<RhythmShipModel>.Instance.GetPlanetOpenLeftTimeString(rhythmShipLevelById.Value.Planet) ?? "");
				return;
			}
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId(ModelBase<RhythmShipModel>.Instance.GetLevelLockTips(this.LevelId) ?? "RhythmShipLevelLockTips", Array.Empty<object>());
		}

		// Token: 0x06040B06 RID: 264966 RVA: 0x01095E30 File Offset: 0x01094030
		public void RefreshItem(int levelId, bool playTinyAni)
		{
			this.LevelId = levelId;
			if (this.LevelId == 0)
			{
				base.SetUiActive(false);
				return;
			}
			base.SetUiActive(true);
			RhythmShipLevel? rhythmShipLevelById = ConfigBase<RhythmShipConfig>.Instance.GetRhythmShipLevelById(this.LevelId);
			if (rhythmShipLevelById == null)
			{
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), rhythmShipLevelById.Value.Name, Array.Empty<object>());
			base.SetTextureByPath(rhythmShipLevelById.Value.IconTexture, base.GetTexture(1), null, null);
			Dictionary<int, RhythmSubLevelPb> subLevelInfoMapByLevelId = ModelBase<RhythmShipModel>.Instance.GetSubLevelInfoMapByLevelId(this.LevelId);
			List<int> list;
			ModelBase<RhythmShipModel>.Instance.LevelSubLevelInfoMap.TryGetValue(this.LevelId, out list);
			list = (list ?? new List<int>());
			for (int i = 0; i < this.StarItemList.Count; i++)
			{
				RhythmShipChoseStarItem rhythmShipChoseStarItem = this.StarItemList[i];
				bool flag = i < list.Count;
				rhythmShipChoseStarItem.SetUiActive(flag);
				if (flag)
				{
					RhythmSubLevelPb rhythmSubLevelPb = null;
					if (subLevelInfoMapByLevelId != null)
					{
						subLevelInfoMapByLevelId.TryGetValue(list[i], out rhythmSubLevelPb);
					}
					bool lightItemActive = rhythmSubLevelPb != null && rhythmSubLevelPb.Cleared;
					rhythmShipChoseStarItem.SetLightItemActive(lightItemActive);
				}
			}
			this.IsLock = !ModelBase<RhythmShipModel>.Instance.GetLevelIsUnlock(this.LevelId);
			base.GetExtendToggle(0).SetToggleState(this.IsLock ? EToggleState.ETT_UnDetermined : EToggleState.ETT_UnChecked, false, false, false);
			base.GetItem(9).SetUIActive(this.IsLock);
			this.RefreshRedDotItem();
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("T_RhythmShipLevelNum0" + rhythmShipLevelById.Value.SortNumber.ToString());
			base.SetTextureByPath(resourcePath, base.GetTexture(2), null, null);
			RhythmShipPlanet? rhythmShipPlanetById = ConfigBase<RhythmShipConfig>.Instance.GetRhythmShipPlanetById(rhythmShipLevelById.Value.Planet);
			ERhythmShipLevelBgType erhythmShipLevelBgType = (ERhythmShipLevelBgType)((rhythmShipPlanetById != null) ? rhythmShipPlanetById.Value.LevelType : 1);
			base.GetItem(7).SetUIActive(erhythmShipLevelBgType == ERhythmShipLevelBgType.BgA);
			base.GetItem(8).SetUIActive(erhythmShipLevelBgType == ERhythmShipLevelBgType.BgB);
			if (playTinyAni)
			{
				LevelSequencePlayer levelSequencePlayerIns = this.LevelSequencePlayerIns;
				if (levelSequencePlayerIns == null)
				{
					return;
				}
				levelSequencePlayerIns.PlayLevelSequenceByName("Tiny", false, null, false);
			}
		}

		// Token: 0x06040B07 RID: 264967 RVA: 0x0109607F File Offset: 0x0109427F
		private void RefreshRedDotItem()
		{
			this.HaveRedDotItem = ModelBase<RhythmShipModel>.Instance.GetLevelRedDotActive(this.LevelId);
			base.GetItem(11).SetUIActive(this.HaveRedDotItem);
		}

		// Token: 0x06040B08 RID: 264968 RVA: 0x010960AA File Offset: 0x010942AA
		private void OnClickToggle(EToggleState state)
		{
			Action<int> onClickToggleCallBack = this.OnClickToggleCallBack;
			if (onClickToggleCallBack == null)
			{
				return;
			}
			onClickToggleCallBack(this.LevelId);
		}

		// Token: 0x06040B09 RID: 264969 RVA: 0x010960C4 File Offset: 0x010942C4
		[NullableContext(2)]
		private void OnRhythmShipRedDotRefresh(List<int> planet, List<int> subLevel, List<int> role)
		{
			if (subLevel == null || !this.HaveRedDotItem)
			{
				return;
			}
			List<int> list;
			ModelBase<RhythmShipModel>.Instance.LevelSubLevelInfoMap.TryGetValue(this.LevelId, out list);
			foreach (int item in subLevel)
			{
				if (list != null && list.Contains(item))
				{
					this.RefreshRedDotItem();
					break;
				}
			}
		}

		// Token: 0x06040B0A RID: 264970 RVA: 0x01096144 File Offset: 0x01094344
		public void SetToggleSelect(bool isSelect)
		{
			base.GetExtendToggle(0).SetToggleState(isSelect ? EToggleState.ETT_Checked : (this.IsLock ? EToggleState.ETT_UnDetermined : EToggleState.ETT_UnChecked), false, false, false);
		}

		// Token: 0x06040B0B RID: 264971 RVA: 0x01096168 File Offset: 0x01094368
		public void LevelSequencePlayerPlay(string name)
		{
			LevelSequencePlayer levelSequencePlayerIns = this.LevelSequencePlayerIns;
			if (levelSequencePlayerIns == null)
			{
				return;
			}
			levelSequencePlayerIns.PlayOrReplaySequenceByName(name, false, null);
		}

		// Token: 0x06040B0C RID: 264972 RVA: 0x01096190 File Offset: 0x01094390
		private void OnLevelSequenceEnd(string name)
		{
			if (name == "Big" || name == "Small")
			{
				if (!this.IsLock && !ModelBase<RhythmShipModel>.Instance.GetLocalHavePlayAniByLevelId(this.LevelId))
				{
					base.GetItem(9).SetUIActive(true);
					LevelSequencePlayer levelSequencePlayerIns = this.LevelSequencePlayerIns;
					if (levelSequencePlayerIns != null)
					{
						levelSequencePlayerIns.PlayLevelSequenceByName("Unlock", false, null, false);
					}
					ModelBase<RhythmShipModel>.Instance.SetLocalHavePlayAniLevelId(this.LevelId);
					return;
				}
			}
			else
			{
				base.GetItem(9).SetUIActive(this.IsLock);
			}
		}

		// Token: 0x040243E4 RID: 148452
		private int LevelId;

		// Token: 0x040243E5 RID: 148453
		private bool IsLock;

		// Token: 0x040243E6 RID: 148454
		private bool HaveRedDotItem;

		// Token: 0x040243E7 RID: 148455
		private readonly List<RhythmShipChoseStarItem> StarItemList = new List<RhythmShipChoseStarItem>();

		// Token: 0x040243E8 RID: 148456
		[Nullable(2)]
		public Action<int> OnClickToggleCallBack;

		// Token: 0x040243E9 RID: 148457
		[Nullable(2)]
		private LevelSequencePlayer LevelSequencePlayerIns;
	}
}
