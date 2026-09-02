using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Marks.MarkItem;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.Marks.MarkItemView
{
	// Token: 0x02005864 RID: 22628
	[NullableContext(1)]
	[Nullable(0)]
	public class ConfigMarkItemView : MarkItemView
	{
		// Token: 0x060398D8 RID: 235736 RVA: 0x00E9A521 File Offset: 0x00E98721
		public ConfigMarkItemView(ConfigMarkItem holder) : base(holder)
		{
		}

		// Token: 0x170092F1 RID: 37617
		// (get) Token: 0x060398D9 RID: 235737 RVA: 0x00E9A52A File Offset: 0x00E9872A
		public MapMark? MarkConfig
		{
			get
			{
				return ((ConfigMarkItem)this.Holder).MarkConfig;
			}
		}

		// Token: 0x060398DA RID: 235738 RVA: 0x00E9A53C File Offset: 0x00E9873C
		protected override void OnDataInitialized(MarkItem holder)
		{
			if (this.LevelSequencer == null)
			{
				this.LevelSequencer = new LevelSequencePlayer(this.RootItem);
			}
		}

		// Token: 0x060398DB RID: 235739 RVA: 0x00E9A558 File Offset: 0x00E98758
		public override void RegisterEvents()
		{
			Entity teleportEntity = this.GetTeleportEntity();
			if (teleportEntity != null)
			{
				Singleton<EventSystem>.Instance.AddWithTarget<int, bool>(teleportEntity, EEventName.OnSceneItemStateChange, new Action<int, bool>(this.OnEntityStateChange));
			}
			Singleton<EventSystem>.Instance.Add(EEventName.LevelPlayMarkGamePlayStateUpdate, new Action<int>(this.OnLevelPlayMarkGamePlayStateUpdate));
			Singleton<EventSystem>.Instance.Add(EEventName.CommonPlayMarkGamePlayStateUpdate, new Action<int>(this.OnLevelPlayMarkGamePlayStateUpdate));
			Singleton<EventSystem>.Instance.Add(EEventName.OnFlagChallengeUpdateStrongholdData, new Action(this.OnFlagChallengeUpdateStrongholdData));
			Singleton<EventSystem>.Instance.Add(EEventName.OnMarkItemShowStateChange, new Action<int>(this.OnLevelPlayMarkGamePlayStateUpdate));
			MarkItem holder = this.Holder;
			if (holder != null && holder.MapType == EMapType.WorldMap)
			{
				Singleton<EventSystem>.Instance.Add<int>(EEventName.WorldMapSubMapChangedFromUpdate, new Action<int>(this.OnSubMapChanged));
			}
		}

		// Token: 0x060398DC RID: 235740 RVA: 0x00E9A630 File Offset: 0x00E98830
		public override void UnRegisterEvents()
		{
			Entity teleportEntity = this.GetTeleportEntity();
			if (teleportEntity != null)
			{
				Singleton<EventSystem>.Instance.RemoveWithTarget<int, bool>(teleportEntity, EEventName.OnSceneItemStateChange, new Action<int, bool>(this.OnEntityStateChange));
			}
			Singleton<EventSystem>.Instance.Remove(EEventName.LevelPlayMarkGamePlayStateUpdate, new Action<int>(this.OnLevelPlayMarkGamePlayStateUpdate));
			Singleton<EventSystem>.Instance.Remove(EEventName.CommonPlayMarkGamePlayStateUpdate, new Action<int>(this.OnLevelPlayMarkGamePlayStateUpdate));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnFlagChallengeUpdateStrongholdData, new Action(this.OnFlagChallengeUpdateStrongholdData));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnMarkItemShowStateChange, new Action<int>(this.OnLevelPlayMarkGamePlayStateUpdate));
			MarkItem holder = this.Holder;
			if (holder != null && holder.MapType == EMapType.WorldMap)
			{
				Singleton<EventSystem>.Instance.Remove<int>(EEventName.WorldMapSubMapChangedFromUpdate, new Action<int>(this.OnSubMapChanged));
			}
		}

		// Token: 0x060398DD RID: 235741 RVA: 0x00E9A708 File Offset: 0x00E98908
		[NullableContext(2)]
		private Entity GetTeleportEntity()
		{
			if (!ConfigBase<MapConfig>.Instance.GetIsInstanceTeleporterExist(this.MarkConfig.Value.MarkId))
			{
				return null;
			}
			InstEntityTeleporter? instEntityTeleportConfigById = ConfigBase<MapConfig>.Instance.GetInstEntityTeleportConfigById(this.MarkConfig.Value.MarkId);
			if (instEntityTeleportConfigById == null)
			{
				return null;
			}
			EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(instEntityTeleportConfigById.Value.EntityConfigId);
			if (entityByPbDataId == null)
			{
				return null;
			}
			return entityByPbDataId.Entity;
		}

		// Token: 0x060398DE RID: 235742 RVA: 0x00E9A78B File Offset: 0x00E9898B
		protected override void OnViewRefresh()
		{
			this.UpdateMultiMapFloorSelectState(true);
			(this.Holder as ConfigMarkItem).UpdateIconPath();
			this.OnIconPathChanged(this.Holder.IconPath);
		}

		// Token: 0x060398DF RID: 235743 RVA: 0x00E9A7B8 File Offset: 0x00E989B8
		public void UpdateMultiMapFloorSelectState(bool isForceUpdate = false)
		{
			MarkItem holder = this.Holder;
			if (holder != null && holder.MapType == EMapType.WorldMap && !isForceUpdate)
			{
				return;
			}
			ConfigMarkItem configMarkItem = this.Holder as ConfigMarkItem;
			bool isSelectThisFloor = configMarkItem.IsSelectThisFloor;
			configMarkItem.IsSelectThisFloor = configMarkItem.GetIsSelectThisFloor();
			if (isSelectThisFloor != configMarkItem.IsSelectThisFloor)
			{
				this.OnIconPathChanged(configMarkItem.IconPath);
			}
		}

		// Token: 0x060398E0 RID: 235744 RVA: 0x00E9A814 File Offset: 0x00E98A14
		public override UniTask PlayUnlockSequence()
		{
			ConfigMarkItemView.<PlayUnlockSequence>d__11 <PlayUnlockSequence>d__;
			<PlayUnlockSequence>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayUnlockSequence>d__.<>4__this = this;
			<PlayUnlockSequence>d__.<>1__state = -1;
			<PlayUnlockSequence>d__.<>t__builder.Start<ConfigMarkItemView.<PlayUnlockSequence>d__11>(ref <PlayUnlockSequence>d__);
			return <PlayUnlockSequence>d__.<>t__builder.Task;
		}

		// Token: 0x060398E1 RID: 235745 RVA: 0x00E9A857 File Offset: 0x00E98A57
		protected override void OnBeforeDestroy()
		{
			if (this.UnlockUiEffect != null)
			{
				ULGUIBPLibrary.DestroyActorWithHierarchy(this.UnlockUiEffect.GetOwner(), true);
			}
			base.OnBeforeDestroy();
		}

		// Token: 0x060398E2 RID: 235746 RVA: 0x00E9A878 File Offset: 0x00E98A78
		public override void OnIconPathChanged(string iconPath)
		{
			if (!base.IsViewReady)
			{
				return;
			}
			UUISprite sprite = base.GetSprite(1);
			base.LoadIcon(sprite, iconPath);
			base.MarkItemChildIconHandle.Update();
			base.MarkItemChildIconHandle.ApplyModified();
			base.MarkItemTopRightIconHandle.Update();
			base.MarkItemTopRightIconHandle.ApplyModified();
		}

		// Token: 0x060398E3 RID: 235747 RVA: 0x00E9A8CC File Offset: 0x00E98ACC
		public virtual void UpdateIcon()
		{
			string iconPath = this.Holder.IconPath;
			this.OnIconPathChanged(iconPath);
		}

		// Token: 0x060398E4 RID: 235748 RVA: 0x00E9A8EC File Offset: 0x00E98AEC
		private void OnEntityStateChange(int stateId, bool _)
		{
			(this.Holder as ConfigMarkItem).UpdateIconPath();
			this.UpdateIcon();
		}

		// Token: 0x060398E5 RID: 235749 RVA: 0x00E9A904 File Offset: 0x00E98B04
		private void OnFlagChallengeUpdateStrongholdData()
		{
			if (this.Holder != null)
			{
				this.OnIconPathChanged(this.Holder.IconPath);
			}
		}

		// Token: 0x060398E6 RID: 235750 RVA: 0x00E9A920 File Offset: 0x00E98B20
		private void OnLevelPlayMarkGamePlayStateUpdate(int markId)
		{
			if (markId != this.MarkConfig.Value.MarkId)
			{
				return;
			}
			this.UpdateIcon();
		}

		// Token: 0x060398E7 RID: 235751 RVA: 0x00E9A94D File Offset: 0x00E98B4D
		protected virtual void OnSubMapChanged(int floorIndex)
		{
			ConfigMarkItem configMarkItem = this.Holder as ConfigMarkItem;
			if (configMarkItem == null)
			{
				return;
			}
			configMarkItem.ChangeSubMap(floorIndex);
		}

		// Token: 0x04020AB5 RID: 133813
		[Nullable(2)]
		private UUIItem UnlockUiEffect;

		// Token: 0x04020AB6 RID: 133814
		[Nullable(2)]
		private LevelSequencePlayer LevelSequencer;
	}
}
