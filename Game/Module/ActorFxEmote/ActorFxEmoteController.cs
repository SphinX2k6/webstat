using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

namespace CSharpScript.Game.Module.ActorFxEmote
{
	// Token: 0x020061C3 RID: 25027
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class ActorFxEmoteController : ControllerBase<ActorFxEmoteController>
	{
		// Token: 0x0603F297 RID: 258711 RVA: 0x010367D3 File Offset: 0x010349D3
		protected override bool OnInit()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnRemoveEntity));
			return true;
		}

		// Token: 0x0603F298 RID: 258712 RVA: 0x010367F2 File Offset: 0x010349F2
		protected override bool OnClear()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnRemoveEntity));
			this.StopAll();
			return true;
		}

		// Token: 0x0603F299 RID: 258713 RVA: 0x01036818 File Offset: 0x01034A18
		public int Play(int entityId, long fxEmoteId, string socketName, global::Vector relativePosition, global::Rotator relativeRotation, global::Vector scale)
		{
			BaseGameplayCueComponent cueComp = this.GetCueComp(entityId);
			if (cueComp == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.RenderEffect;
				ELogAuthor author = ELogAuthor.ZJL;
				string message = "[ActorFxEmote] 播放失败：找不到 GameplayCue 组件";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("EntityId", entityId);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return 0;
			}
			string text = socketName ?? "__default";
			ActorFxEmoteData orCreateEntityData = ModelBase<ActorFxEmoteModel>.Instance.GetOrCreateEntityData(entityId);
			this.RemoveSocketHandle(orCreateEntityData, cueComp, text);
			if (cueComp.GetCueByCueId(fxEmoteId) != null)
			{
				this.RemoveHandlesByCueId(orCreateEntityData, cueComp, fxEmoteId);
			}
			GameplayCueBase cueByCueId = cueComp.GetCueByCueId(fxEmoteId);
			GameplayCueParam value = new GameplayCueParam
			{
				RelativePositionOverride = new FVector?(new FVector((float)relativePosition.X, (float)relativePosition.Y, (float)relativePosition.Z)),
				RelativeRotationOverride = new FVector?(new FVector(relativeRotation.Pitch, relativeRotation.Yaw, relativeRotation.Roll)),
				ScaleOverride = new FVector?(new FVector((float)scale.X, (float)scale.Y, (float)scale.Z))
			};
			if (!string.IsNullOrEmpty(socketName))
			{
				value.SocketNameOverride = socketName;
			}
			int num = cueComp.AddCue(fxEmoteId, new GameplayCueParam?(value));
			if (num == 0 || num == -1)
			{
				return 0;
			}
			if (cueByCueId != null)
			{
				GameplayCueBase cueByHandle = cueComp.GetCueByHandle((long)num);
				if (cueByHandle != null)
				{
					ActorFxEmoteController.GameplayCueEffectOverrideImpl @override = new ActorFxEmoteController.GameplayCueEffectOverrideImpl
					{
						SocketName = socketName,
						RelativePosition = new FVector?(new FVector((float)relativePosition.X, (float)relativePosition.Y, (float)relativePosition.Z)),
						RelativeRotation = new FVector?(new FVector(relativeRotation.Pitch, relativeRotation.Yaw, relativeRotation.Roll)),
						Scale = new FVector?(new FVector((float)scale.X, (float)scale.Y, (float)scale.Z))
					};
					cueByHandle.OnGameplayCueEffectOverride(@override);
				}
			}
			orCreateEntityData.SocketHandles[text] = num;
			return num;
		}

		// Token: 0x0603F29A RID: 258714 RVA: 0x010369FC File Offset: 0x01034BFC
		public void StopSocket(int entityId, string socketName)
		{
			ActorFxEmoteData entityData = ModelBase<ActorFxEmoteModel>.Instance.GetEntityData(entityId);
			if (entityData == null)
			{
				return;
			}
			BaseGameplayCueComponent cueComp = this.GetCueComp(entityId);
			if (cueComp == null)
			{
				return;
			}
			this.RemoveSocketHandle(entityData, cueComp, socketName ?? "__default");
		}

		// Token: 0x0603F29B RID: 258715 RVA: 0x01036A38 File Offset: 0x01034C38
		public void StopEntity(int entityId)
		{
			ActorFxEmoteData entityData = ModelBase<ActorFxEmoteModel>.Instance.GetEntityData(entityId);
			if (entityData == null)
			{
				return;
			}
			BaseGameplayCueComponent cueComp = this.GetCueComp(entityId);
			if (cueComp != null)
			{
				foreach (int num in entityData.SocketHandles.Values)
				{
					cueComp.RemoveCueByHandle((long)num);
				}
			}
			entityData.SocketHandles.Clear();
			ModelBase<ActorFxEmoteModel>.Instance.RemoveEntityData(entityId);
		}

		// Token: 0x0603F29C RID: 258716 RVA: 0x01036AC4 File Offset: 0x01034CC4
		public void StopAll()
		{
			ModelBase<ActorFxEmoteModel>.Instance.ForEachEntityData(delegate(int entityId, ActorFxEmoteData entityData)
			{
				BaseGameplayCueComponent cueComp = this.GetCueComp(entityId);
				if (cueComp != null)
				{
					foreach (int num in entityData.SocketHandles.Values)
					{
						cueComp.RemoveCueByHandle((long)num);
					}
				}
				entityData.SocketHandles.Clear();
			});
		}

		// Token: 0x0603F29D RID: 258717 RVA: 0x01036ADC File Offset: 0x01034CDC
		private void RemoveSocketHandle(ActorFxEmoteData entityData, BaseGameplayCueComponent queComp, string socketKey)
		{
			int num;
			if (entityData.SocketHandles.TryGetValue(socketKey, out num) && num != 0)
			{
				queComp.RemoveCueByHandle((long)num);
			}
			entityData.SocketHandles.Remove(socketKey);
		}

		// Token: 0x0603F29E RID: 258718 RVA: 0x01036B14 File Offset: 0x01034D14
		private void RemoveHandlesByCueId(ActorFxEmoteData entityData, BaseGameplayCueComponent queComp, long cueId)
		{
			foreach (KeyValuePair<string, int> keyValuePair in entityData.SocketHandles.ToArray<KeyValuePair<string, int>>())
			{
				string text;
				int num;
				keyValuePair.Deconstruct(out text, out num);
				string key = text;
				int num2 = num;
				GameplayCueBase cueByHandle = queComp.GetCueByHandle((long)num2);
				if (cueByHandle != null && cueByHandle.CueConfig.Id == cueId)
				{
					queComp.RemoveCueByHandle((long)num2);
					entityData.SocketHandles.Remove(key);
				}
			}
		}

		// Token: 0x0603F29F RID: 258719 RVA: 0x01036B88 File Offset: 0x01034D88
		[NullableContext(2)]
		private BaseGameplayCueComponent GetCueComp(int entityId)
		{
			return Singleton<EntitySystem>.Instance.GetComponent<BaseGameplayCueComponent>(entityId);
		}

		// Token: 0x0603F2A0 RID: 258720 RVA: 0x01036B95 File Offset: 0x01034D95
		private void OnRemoveEntity(ERemoveEntityType removeType, EntityHandle handle)
		{
			if (handle == null)
			{
				return;
			}
			this.StopEntity(handle.Id);
		}

		// Token: 0x0200C30A RID: 49930
		[NullableContext(2)]
		[Nullable(0)]
		private class GameplayCueEffectOverrideImpl : IGameplayCueEffectOverride
		{
			// Token: 0x1700AA4C RID: 43596
			// (get) Token: 0x0604E757 RID: 321367 RVA: 0x015C3C66 File Offset: 0x015C1E66
			// (set) Token: 0x0604E758 RID: 321368 RVA: 0x015C3C6E File Offset: 0x015C1E6E
			public string SocketName { get; set; }

			// Token: 0x1700AA4D RID: 43597
			// (get) Token: 0x0604E759 RID: 321369 RVA: 0x015C3C77 File Offset: 0x015C1E77
			// (set) Token: 0x0604E75A RID: 321370 RVA: 0x015C3C7F File Offset: 0x015C1E7F
			public FVector? RelativePosition { get; set; }

			// Token: 0x1700AA4E RID: 43598
			// (get) Token: 0x0604E75B RID: 321371 RVA: 0x015C3C88 File Offset: 0x015C1E88
			// (set) Token: 0x0604E75C RID: 321372 RVA: 0x015C3C90 File Offset: 0x015C1E90
			public FVector? RelativeRotation { get; set; }

			// Token: 0x1700AA4F RID: 43599
			// (get) Token: 0x0604E75D RID: 321373 RVA: 0x015C3C99 File Offset: 0x015C1E99
			// (set) Token: 0x0604E75E RID: 321374 RVA: 0x015C3CA1 File Offset: 0x015C1EA1
			public FVector? Scale { get; set; }
		}
	}
}
