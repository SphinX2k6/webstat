using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Fight.Enum;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Abilities.Follow
{
	// Token: 0x02004966 RID: 18790
	[NullableContext(1)]
	[Nullable(0)]
	public class FollowShooterAttachStrategies : IStaticVariableResetter
	{
		// Token: 0x06031209 RID: 201225 RVA: 0x00C3A78E File Offset: 0x00C3898E
		private static void registerFollowShooterAttachStrategy(BPEFollowShooterAttachStrategy strategyEnum, IFollowShooterAttachStrategy strategy)
		{
			FollowShooterAttachStrategies.strategyRegistry[strategyEnum] = strategy;
		}

		// Token: 0x0603120A RID: 201226 RVA: 0x00C3A79C File Offset: 0x00C3899C
		public static IFollowShooterAttachStrategy getFollowShooterAttachStrategy(BPEFollowShooterAttachStrategy strategyEnum)
		{
			Dictionary<BPEFollowShooterAttachStrategy, IFollowShooterAttachStrategy> dictionary = FollowShooterAttachStrategies.strategyRegistry;
			IFollowShooterAttachStrategy result;
			if (dictionary != null && dictionary.TryGetValue(strategyEnum, out result))
			{
				return result;
			}
			return FollowShooterAttachStrategies.strategyRegistry[BPEFollowShooterAttachStrategy.DirectAttach];
		}

		// Token: 0x0603120B RID: 201227 RVA: 0x00C3A7CC File Offset: 0x00C389CC
		public static List<IFollowShooterAttachStrategy> getAllFollowShooterAttachStrategies()
		{
			return new List<IFollowShooterAttachStrategy>(FollowShooterAttachStrategies.strategyRegistry.Values);
		}

		// Token: 0x0603120C RID: 201228 RVA: 0x00C3A7DD File Offset: 0x00C389DD
		public static void setSceneComponentAttachStrategy(USceneComponent sceneComponent, BPEFollowShooterAttachStrategy strategyEnum)
		{
			FollowShooterAttachStrategies.sceneComponentAttachStrategyMap[sceneComponent] = strategyEnum;
		}

		// Token: 0x0603120D RID: 201229 RVA: 0x00C3A7EB File Offset: 0x00C389EB
		public static BPEFollowShooterAttachStrategy getSceneComponentAttachStrategy(USceneComponent sceneComponent)
		{
			return FollowShooterAttachStrategies.sceneComponentAttachStrategyMap.GetValueOrDefault(sceneComponent, BPEFollowShooterAttachStrategy.DirectAttach);
		}

		// Token: 0x0603120E RID: 201230 RVA: 0x00C3A7FC File Offset: 0x00C389FC
		public static void clearFollowShooterAttachStrategiesStateForSceneComponent(USceneComponent sceneComponent)
		{
			foreach (IFollowShooterAttachStrategy followShooterAttachStrategy in FollowShooterAttachStrategies.strategyRegistry.Values)
			{
				SocketTrackingStrategy socketTrackingStrategy = followShooterAttachStrategy as SocketTrackingStrategy;
				if (socketTrackingStrategy != null)
				{
					socketTrackingStrategy.ClearForSceneComponent(sceneComponent);
				}
			}
			FollowShooterAttachStrategies.sceneComponentAttachStrategyMap.Remove(sceneComponent);
		}

		// Token: 0x0603120F RID: 201231 RVA: 0x00C3A868 File Offset: 0x00C38A68
		public static void CreateStaticDefaultValue()
		{
			FollowShooterAttachStrategies.strategyRegistry = new Dictionary<BPEFollowShooterAttachStrategy, IFollowShooterAttachStrategy>();
			FollowShooterAttachStrategies.sceneComponentAttachStrategyMap = new Dictionary<USceneComponent, BPEFollowShooterAttachStrategy>();
			FollowShooterAttachStrategies.registerFollowShooterAttachStrategy(BPEFollowShooterAttachStrategy.DirectAttach, new DirectAttachStrategy());
			FollowShooterAttachStrategies.registerFollowShooterAttachStrategy(BPEFollowShooterAttachStrategy.SocketTracking, new SocketTrackingStrategy());
		}

		// Token: 0x06031210 RID: 201232 RVA: 0x00C3A894 File Offset: 0x00C38A94
		public static void ResetStaticDefaultValue()
		{
			FollowShooterAttachStrategies.strategyRegistry = null;
			FollowShooterAttachStrategies.sceneComponentAttachStrategyMap = null;
		}

		// Token: 0x06031211 RID: 201233 RVA: 0x00C3A8A2 File Offset: 0x00C38AA2
		static FollowShooterAttachStrategies()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(FollowShooterAttachStrategies.CreateStaticDefaultValue), new Action(FollowShooterAttachStrategies.ResetStaticDefaultValue));
		}

		// Token: 0x0401C493 RID: 115859
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private static Dictionary<BPEFollowShooterAttachStrategy, IFollowShooterAttachStrategy> strategyRegistry;

		// Token: 0x0401C494 RID: 115860
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private static Dictionary<USceneComponent, BPEFollowShooterAttachStrategy> sceneComponentAttachStrategyMap;
	}
}
