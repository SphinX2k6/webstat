using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.NewWorld.Character.Custom.Components;
using CSharpScript.Game.NewWorld.SceneItem;

namespace CSharpScript.Game.NewWorld.Common.Component
{
	// Token: 0x020048C0 RID: 18624
	[NullableContext(2)]
	[Nullable(0)]
	public class CustomAudioControlComponent : EntityComponent
	{
		// Token: 0x06030906 RID: 198918 RVA: 0x00BF041C File Offset: 0x00BEE61C
		protected override bool OnInitData(IEntityArgs args = null)
		{
			EntityCustomAudioComponent entityCustomAudioComponent = args.GetP1<CreateEntityData>().GetParam<CustomAudioControlComponent>() as EntityCustomAudioComponent;
			this.AudioRangeType = entityCustomAudioComponent.AudioRangeType;
			this.AudioControlConfig = entityCustomAudioComponent.AudioControlType;
			this.CreatureDataComp = base.Entity.GetComponent<CreatureDataComponent>();
			return true;
		}

		// Token: 0x06030907 RID: 198919 RVA: 0x00BF0464 File Offset: 0x00BEE664
		protected override bool OnStart()
		{
			switch (this.AudioRangeType)
			{
			case EAudioRangeType.SceneActorRefComp:
				this.RefComp = base.Entity.GetComponent<SceneItemReferenceComponent>();
				if (!this.RefComp)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Entity;
					ELogAuthor author = ELogAuthor.ZYL;
					string message = "SceneItemReferenceComponent不存在";
					string item = "ConfigId";
					CreatureDataComponent creatureDataComp = this.CreatureDataComp;
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>(item, (creatureDataComp != null) ? new int?(creatureDataComp.GetPbDataId()) : null);
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					return false;
				}
				this.RefComp.AddOnPlayerOverlapCallback(new Action<bool>(this.OnPlayerInOutRange), false);
				break;
			case EAudioRangeType.RangeComp:
				if (!base.Entity.GetComponent<CSharpScript.Game.NewWorld.Character.Custom.Components.RangeComponent>())
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.Entity;
					ELogAuthor author2 = ELogAuthor.ZYL;
					string message2 = "RangeComponent不存在";
					string item2 = "ConfigId";
					CreatureDataComponent creatureDataComp2 = this.CreatureDataComp;
					ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>(item2, (creatureDataComp2 != null) ? new int?(creatureDataComp2.GetPbDataId()) : null);
					instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
					return false;
				}
				if (!Singleton<EventSystem>.Instance.HasWithTarget<bool>(base.Entity, EEventName.OnMyPlayerInOutRangeLocal, new Action<bool>(this.OnPlayerInOutRange)))
				{
					Singleton<EventSystem>.Instance.AddWithTargetUseHoldKey(this, base.Entity, EEventName.OnMyPlayerInOutRangeLocal, new Action<bool>(this.OnPlayerInOutRange));
				}
				break;
			case EAudioRangeType.AOI:
				this.OnPlayerInOutRange(true);
				break;
			}
			return true;
		}

		// Token: 0x06030908 RID: 198920 RVA: 0x00BF05CC File Offset: 0x00BEE7CC
		protected override bool OnEnd()
		{
			switch (this.AudioRangeType)
			{
			case EAudioRangeType.SceneActorRefComp:
				if (this.RefComp != null)
				{
					this.RefComp.RemoveOnPlayerOverlapCallback(new Action<bool>(this.OnPlayerInOutRange));
					this.RefComp = null;
				}
				if (this.PlayerInRangeReal)
				{
					this.OnPlayerInOutRange(false);
				}
				break;
			case EAudioRangeType.RangeComp:
				if (Singleton<EventSystem>.Instance.HasWithTarget<bool>(base.Entity, EEventName.OnMyPlayerInOutRangeLocal, new Action<bool>(this.OnPlayerInOutRange)))
				{
					Singleton<EventSystem>.Instance.RemoveWithTargetUseKey(this, base.Entity, EEventName.OnMyPlayerInOutRangeLocal, new Action<bool>(this.OnPlayerInOutRange));
				}
				break;
			case EAudioRangeType.AOI:
				this.OnPlayerInOutRange(false);
				break;
			}
			return true;
		}

		// Token: 0x06030909 RID: 198921 RVA: 0x00BF0680 File Offset: 0x00BEE880
		[NullableContext(1)]
		protected override void OnDisable(string reason)
		{
			IAudioControlType audioControlConfig = this.AudioControlConfig;
			if ((((audioControlConfig != null) ? new EAudioControlType?(audioControlConfig.Type) : null) ?? EAudioControlType.Traffic) == EAudioControlType.Gramophone)
			{
				this.HandleDisableGramophone(reason);
			}
		}

		// Token: 0x0603090A RID: 198922 RVA: 0x00BF06C8 File Offset: 0x00BEE8C8
		protected override void OnEnable()
		{
			IAudioControlType audioControlConfig = this.AudioControlConfig;
			if ((((audioControlConfig != null) ? new EAudioControlType?(audioControlConfig.Type) : null) ?? EAudioControlType.Traffic) == EAudioControlType.Gramophone)
			{
				this.HandleEnableGramophone();
			}
		}

		// Token: 0x0603090B RID: 198923 RVA: 0x00BF0710 File Offset: 0x00BEE910
		private void OnPlayerInOutRange(bool isEnter)
		{
			if (isEnter == this.PlayerInRangeReal)
			{
				return;
			}
			this.PlayerInRangeReal = isEnter;
			IAudioControlType audioControlConfig = this.AudioControlConfig;
			if ((((audioControlConfig != null) ? new EAudioControlType?(audioControlConfig.Type) : null) ?? EAudioControlType.Traffic) == EAudioControlType.Gramophone)
			{
				this.HandlePlayerInOutGramophoneRange(isEnter);
			}
		}

		// Token: 0x0603090C RID: 198924 RVA: 0x00BF0767 File Offset: 0x00BEE967
		private void HandlePlayerInOutGramophoneRange(bool isEnter)
		{
			if (isEnter)
			{
				ControllerBase<PhonographController>.Instance.PlayMusicByEntityId(base.Entity.Id);
				return;
			}
			ControllerBase<PhonographController>.Instance.StopMusicByEntityId(base.Entity.Id);
		}

		// Token: 0x0603090D RID: 198925 RVA: 0x00BF0797 File Offset: 0x00BEE997
		[NullableContext(1)]
		private void HandleDisableGramophone(string reason)
		{
			if (this.PlayerInRangeReal)
			{
				this.HandlePlayerInOutGramophoneRange(false);
			}
		}

		// Token: 0x0603090E RID: 198926 RVA: 0x00BF07A8 File Offset: 0x00BEE9A8
		private void HandleEnableGramophone()
		{
			if (this.PlayerInRangeReal)
			{
				this.HandlePlayerInOutGramophoneRange(true);
			}
		}

		// Token: 0x0603090F RID: 198927 RVA: 0x00BF07B9 File Offset: 0x00BEE9B9
		public IAudioControlType GetAudioControlConfig()
		{
			return this.AudioControlConfig;
		}

		// Token: 0x06030910 RID: 198928 RVA: 0x00BF07C4 File Offset: 0x00BEE9C4
		[NullableContext(1)]
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			CustomAudioControlComponent customAudioControlComponent = (CustomAudioControlComponent)componentTemplate;
			if (base.CanResetComponentProperty("AudioControlConfig"))
			{
				if (customAudioControlComponent.AudioControlConfig == null)
				{
					this.AudioControlConfig = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<IAudioControlType>(this.AudioControlConfig), "AudioControlConfig"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("AudioRangeType"))
			{
				this.AudioRangeType = customAudioControlComponent.AudioRangeType;
			}
			if (base.CanResetComponentProperty("CreatureDataComp"))
			{
				if (customAudioControlComponent.CreatureDataComp == null)
				{
					this.CreatureDataComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CreatureDataComponent>(this.CreatureDataComp), "CreatureDataComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("RefComp"))
			{
				if (customAudioControlComponent.RefComp == null)
				{
					this.RefComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<SceneItemReferenceComponent>(this.RefComp), "RefComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("PlayerInRangeReal"))
			{
				this.PlayerInRangeReal = customAudioControlComponent.PlayerInRangeReal;
			}
			return true;
		}

		// Token: 0x0401BE8B RID: 114315
		private IAudioControlType AudioControlConfig;

		// Token: 0x0401BE8C RID: 114316
		private EAudioRangeType AudioRangeType = EAudioRangeType.AOI;

		// Token: 0x0401BE8D RID: 114317
		private CreatureDataComponent CreatureDataComp;

		// Token: 0x0401BE8E RID: 114318
		private SceneItemReferenceComponent RefComp;

		// Token: 0x0401BE8F RID: 114319
		private bool PlayerInRangeReal;
	}
}
