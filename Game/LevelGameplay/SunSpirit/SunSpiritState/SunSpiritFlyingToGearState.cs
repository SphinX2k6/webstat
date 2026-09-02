using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.NewWorld.SceneItem;

namespace CSharpScript.Game.LevelGamePlay.SunSpirit.SunSpiritState
{
	// Token: 0x02006AAA RID: 27306
	[NullableContext(1)]
	[Nullable(0)]
	public class SunSpiritFlyingToGearState : SunSpiritFlyingEffectState
	{
		// Token: 0x06043862 RID: 276578 RVA: 0x011681E8 File Offset: 0x011663E8
		public SunSpiritFlyingToGearState(SunSpiritData sunSpiritData, float waitBeforeFlyDuration, float flyingDuration, int gearConfigId, int gearSocketIndex, [Nullable(2)] Action flyingEndCallback) : base(ESunSpiritStateType.FlyingToGear, sunSpiritData, waitBeforeFlyDuration, flyingDuration)
		{
			this.GearConfigId = gearConfigId;
			this.GearSocketIndex = gearSocketIndex;
			this.FlyingFinishCallback = flyingEndCallback;
			this.FlyingInterruptCallback = flyingEndCallback;
			this.FlyingTargetGetter = delegate(Vector outPos, Quat outRot)
			{
				CreatureModel instance = ModelBase<CreatureModel>.Instance;
				object obj;
				if (instance == null)
				{
					obj = null;
				}
				else
				{
					EntityHandle entityByPbDataId = instance.GetEntityByPbDataId(this.GearConfigId);
					if (entityByPbDataId == null)
					{
						obj = null;
					}
					else
					{
						WorldEntity entity = entityByPbDataId.Entity;
						obj = ((entity != null) ? entity.GetComponent<SceneItemSunSpiritGearComponent>() : null);
					}
				}
				object obj2 = obj;
				return obj2 != null && obj2.GetSunSpiritSocketLocAndRot(this.GearSocketIndex, outPos, outRot);
			};
		}

		// Token: 0x06043863 RID: 276579 RVA: 0x01168228 File Offset: 0x01166428
		public override bool IsSameState(SunSpiritBaseState otherState)
		{
			if (base.IsSameState(otherState))
			{
				SunSpiritFlyingToGearState sunSpiritFlyingToGearState = otherState as SunSpiritFlyingToGearState;
				if (sunSpiritFlyingToGearState != null && this.GearConfigId == sunSpiritFlyingToGearState.GearConfigId)
				{
					return this.GearSocketIndex == sunSpiritFlyingToGearState.GearSocketIndex;
				}
			}
			return false;
		}

		// Token: 0x06043864 RID: 276580 RVA: 0x01168266 File Offset: 0x01166466
		protected override void OnSunSpiritFlyToTargetEnd(bool bKeepEffect = false, bool bIsInterrupt = false)
		{
			base.OnSunSpiritFlyToTargetEnd(bKeepEffect, bIsInterrupt);
			this.SunSpiritData.StopAllAndSetNextSunSpiritState(new SunSpiritOccupiedByGearState(this.SunSpiritData, this.GearConfigId, this.GearSocketIndex), false);
		}

		// Token: 0x06043865 RID: 276581 RVA: 0x01168294 File Offset: 0x01166494
		protected override bool OnEnter()
		{
			base.OnEnter();
			if (this.SunSpiritData.Transform == null || this.SunSpiritData.Transform.GetLocation().IsZero())
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.SunSpirit;
				ELogAuthor author = ELogAuthor.ZYL;
				string message = "日灵: SunSpiritFlyingToGearState.OnEnter 找不到已有位置，重设飞行起点";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("SpiritConfigId", this.SunSpiritData.ConfigId);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				TsBaseCharacter baseCharacter = Global.BaseCharacter;
				CharacterActorComponent characterActorComponent = (baseCharacter != null) ? baseCharacter.CharacterActorComponent : null;
				if (characterActorComponent == null)
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.SunSpirit;
					ELogAuthor author2 = ELogAuthor.ZYL;
					string message2 = "日灵: SunSpiritFlyingToGearState.OnEnter 重设飞行起点位置失败";
					ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("SpiritConfigId", this.SunSpiritData.ConfigId);
					instance2.Warn(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
					return false;
				}
				this.SunSpiritData.SetLocationAndRotation(characterActorComponent.ActorLocationProxy, characterActorComponent.ActorRotationProxy);
			}
			return true;
		}

		// Token: 0x04025B9E RID: 154526
		public readonly int GearConfigId;

		// Token: 0x04025B9F RID: 154527
		public readonly int GearSocketIndex;
	}
}
