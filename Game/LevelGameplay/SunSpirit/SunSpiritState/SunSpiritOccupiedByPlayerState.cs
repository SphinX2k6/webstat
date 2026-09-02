using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay.SunSpirit.SunSpiritPerform;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.SunSpirit.SunSpiritState
{
	// Token: 0x02006AAE RID: 27310
	[NullableContext(1)]
	[Nullable(0)]
	public class SunSpiritOccupiedByPlayerState : SunSpiritBaseState
	{
		// Token: 0x06043873 RID: 276595 RVA: 0x01168B13 File Offset: 0x01166D13
		public SunSpiritOccupiedByPlayerState(SunSpiritData sunSpiritData) : base(ESunSpiritStateType.OccupiedByPlayer, sunSpiritData)
		{
		}

		// Token: 0x06043874 RID: 276596 RVA: 0x01168B20 File Offset: 0x01166D20
		protected override bool OnEnter()
		{
			SunSpiritBasePerform sunSpiritPerform = this.SunSpiritData.GetSunSpiritPerform();
			if (!(sunSpiritPerform is SunSpiritCrowdPerform))
			{
				Transform transform = Transform.Create();
				this.SunSpiritData.ChangeSunSpiritPerform(new SunSpiritCrowdPerform(this.SunSpiritData, this.GetInitTransform(transform) ? transform : null, true, false));
			}
			else
			{
				((SunSpiritCrowdPerform)sunSpiritPerform).UpdateCtrlByCrowdAi(true);
				((SunSpiritCrowdPerform)sunSpiritPerform).UpdateForceSpawn(false);
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.OnSunSpiritOccupiedByPlayerChanged);
			return true;
		}

		// Token: 0x06043875 RID: 276597 RVA: 0x01168B97 File Offset: 0x01166D97
		protected override void OnExit()
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.OnSunSpiritOccupiedByPlayerChanged);
		}

		// Token: 0x06043876 RID: 276598 RVA: 0x01168BAC File Offset: 0x01166DAC
		private bool CheckTransformValid(Transform transform)
		{
			SunSpiritModel instance = ModelBase<SunSpiritModel>.Instance;
			SunSpiritConfig sunSpiritConfig = (instance != null) ? instance.GetSunSpiritConfig() : null;
			if (sunSpiritConfig == null)
			{
				return false;
			}
			if (transform == null || transform.GetLocation().IsZero())
			{
				return false;
			}
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			if (((baseCharacter != null) ? baseCharacter.CharacterActorComponent : null) == null)
			{
				return false;
			}
			UKuroCrowdAiSubsystem crowdAiSubsystem = ControllerBase<CrowdAiController>.Instance.CrowdAiSubsystem;
			if (crowdAiSubsystem == null)
			{
				return false;
			}
			UKuroCrowdAiSubsystem ukuroCrowdAiSubsystem = crowdAiSubsystem;
			FVector fvector = transform.GetLocation().ToUeVectorOld();
			return !ukuroCrowdAiSubsystem.QueryUsablePositionForBoid(fvector, 0f, sunSpiritConfig.AroundPlayerPosQueryBoidRadius, sunSpiritConfig.AroundPlayerPosQueryMaxTryCount).IsZero();
		}

		// Token: 0x06043877 RID: 276599 RVA: 0x01168C3C File Offset: 0x01166E3C
		private unsafe bool GetInitTransform(Transform outTransform)
		{
			SunSpiritModel instance = ModelBase<SunSpiritModel>.Instance;
			SunSpiritConfig sunSpiritConfig = (instance != null) ? instance.GetSunSpiritConfig() : null;
			if (sunSpiritConfig == null)
			{
				return false;
			}
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			CharacterActorComponent characterActorComponent = (baseCharacter != null) ? baseCharacter.CharacterActorComponent : null;
			if (characterActorComponent == null)
			{
				return false;
			}
			Transform transform = this.SunSpiritData.Transform;
			if (transform == null || !this.CheckTransformValid(transform))
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module = ELogModule.SunSpirit;
				ELogAuthor author = ELogAuthor.ZYL;
				string message = "日灵: SunSpiritFlyingToPlayerState.GetInitTransform 当前位置不合法，重新查询角色附近的可用位置";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("SpiritConfigId", this.SunSpiritData.ConfigId);
				instance2.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				bool flag = false;
				UKuroCrowdAiSubsystem crowdAiSubsystem = ControllerBase<CrowdAiController>.Instance.CrowdAiSubsystem;
				if (crowdAiSubsystem != null)
				{
					UKuroCrowdAiSubsystem ukuroCrowdAiSubsystem = crowdAiSubsystem;
					FVector fvector = characterActorComponent.ActorLocationProxy.ToUeVectorOld();
					FVector fvector2 = ukuroCrowdAiSubsystem.QueryUsablePositionForBoid(fvector, sunSpiritConfig.AroundPlayerPosQueryRadius, sunSpiritConfig.AroundPlayerPosQueryBoidRadius, sunSpiritConfig.AroundPlayerPosQueryMaxTryCount);
					if (!fvector2.IsZero())
					{
						outTransform.SetLocation(fvector2);
						outTransform.SetRotation(characterActorComponent.ActorQuatProxy);
						flag = true;
					}
				}
				if (!flag)
				{
					Log instance3 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.SunSpirit;
					ELogAuthor author2 = ELogAuthor.ZYL;
					string message2 = "日灵: SunSpiritFlyingToPlayerState.GetInitTransform 查找角色附近的可用位置失败";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("SpiritConfigId", this.SunSpiritData.ConfigId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("TargetLocation", characterActorComponent.ActorLocationProxy);
					instance3.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
					return false;
				}
			}
			else
			{
				outTransform.Set(transform.GetLocation(), transform.GetRotation(), transform.GetScale3D());
			}
			SunSpiritModel instance4 = ModelBase<SunSpiritModel>.Instance;
			float? num;
			if (instance4 == null)
			{
				num = null;
			}
			else
			{
				SunSpiritCollectComponent sunSpiritConfigByConfigId = instance4.GetSunSpiritConfigByConfigId(this.SunSpiritData.InstId, this.SunSpiritData.ConfigId);
				num = ((sunSpiritConfigByConfigId != null) ? sunSpiritConfigByConfigId.SunSpiritScale : null);
			}
			float? num2 = num;
			double num3 = (double)num2.GetValueOrDefault(1f);
			if (num3 == 0.0)
			{
				num3 = 1.0;
			}
			outTransform.GetScale3D().Set(num3, num3, num3);
			return true;
		}
	}
}
