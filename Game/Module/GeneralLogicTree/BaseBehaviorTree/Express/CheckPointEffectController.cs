using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Effect;
using CSharpScript.Game.Module.GeneralLogicTree.BehaviorNode.ChildQuestNode;
using CSharpScript.Game.Utils;
using UnrealEngine;

namespace CSharpScript.Game.Module.GeneralLogicTree.BaseBehaviorTree.Express
{
	// Token: 0x02005D00 RID: 23808
	[NullableContext(1)]
	[Nullable(0)]
	public class CheckPointEffectController
	{
		// Token: 0x0603C05D RID: 245853 RVA: 0x00F39AEA File Offset: 0x00F37CEA
		public CheckPointEffectController(Blackboard Blackboard)
		{
		}

		// Token: 0x0603C05E RID: 245854 RVA: 0x00F39B10 File Offset: 0x00F37D10
		public void EnableAllEffects(bool value)
		{
			foreach (KeyValuePair<int, CheckPointEffectController.CheckPointEffectInfo> keyValuePair in this.EffectSpawnInfos)
			{
				int num;
				CheckPointEffectController.CheckPointEffectInfo checkPointEffectInfo;
				keyValuePair.Deconstruct(out num, out checkPointEffectInfo);
				int nodeId = num;
				CheckPointEffectController.CheckPointEffectInfo info = checkPointEffectInfo;
				if (value)
				{
					this.SpawnEffect(nodeId, info);
				}
				else
				{
					this.StopEffect(nodeId);
				}
			}
		}

		// Token: 0x0603C05F RID: 245855 RVA: 0x00F39B84 File Offset: 0x00F37D84
		public void UpdateOnChildQuestNodeStatusChange(ChildQuestNodeBase node, bool bStart, bool bEnd)
		{
			if (node.TrackTarget != null)
			{
				ReachAreaBehaviorNode reachAreaBehaviorNode = node as ReachAreaBehaviorNode;
				if (reachAreaBehaviorNode != null)
				{
					if (bStart)
					{
						bool isOccupied = this.<Blackboard>P.IsOccupied;
						if (!string.IsNullOrEmpty(reachAreaBehaviorNode.EffectPathKey))
						{
							this.OnNodeStart(node.NodeId, reachAreaBehaviorNode.EffectPathKey, reachAreaBehaviorNode.GetTargetPosition(), isOccupied);
						}
					}
					if (bEnd)
					{
						this.OnNodeEnd(node.NodeId);
					}
					return;
				}
			}
		}

		// Token: 0x0603C060 RID: 245856 RVA: 0x00F39BE8 File Offset: 0x00F37DE8
		private void OnNodeStart(int nodeId, string effectPathKey, Vector effectSpawnPosition, bool bOccupied)
		{
			CheckPointEffectController.CheckPointEffectInfo checkPointEffectInfo;
			if (this.EffectSpawnInfos.TryGetValue(nodeId, out checkPointEffectInfo))
			{
				return;
			}
			checkPointEffectInfo = new CheckPointEffectController.CheckPointEffectInfo
			{
				EffectPathKey = effectPathKey,
				EffectSpawnPosition = effectSpawnPosition
			};
			this.EffectSpawnInfos[nodeId] = checkPointEffectInfo;
			if (bOccupied)
			{
				return;
			}
			this.SpawnEffect(nodeId, checkPointEffectInfo);
		}

		// Token: 0x0603C061 RID: 245857 RVA: 0x00F39C34 File Offset: 0x00F37E34
		private void OnNodeEnd(int nodeId)
		{
			this.EffectSpawnInfos.Remove(nodeId);
			this.StopEffect(nodeId);
		}

		// Token: 0x0603C062 RID: 245858 RVA: 0x00F39C4A File Offset: 0x00F37E4A
		public void OnBtApplyExpressionOccupation(bool bSelf)
		{
			if (bSelf)
			{
				return;
			}
			this.EnableAllEffects(true);
		}

		// Token: 0x0603C063 RID: 245859 RVA: 0x00F39C57 File Offset: 0x00F37E57
		public void OnBtReleaseExpressionOccupation(bool bSelf)
		{
			if (bSelf)
			{
				return;
			}
			this.EnableAllEffects(false);
		}

		// Token: 0x0603C064 RID: 245860 RVA: 0x00F39C64 File Offset: 0x00F37E64
		private void SpawnEffect(int nodeId, CheckPointEffectController.CheckPointEffectInfo info)
		{
			string effectPath = EffectUtil.GetEffectPath((!string.IsNullOrEmpty(info.EffectPathKey)) ? info.EffectPathKey : "DA_Fx_Group_Sl3_Cishi_10idle");
			if (StringUtils.IsBlank(effectPath))
			{
				return;
			}
			EffectSystem instance = Singleton<EffectSystem>.Instance;
			UObject world = GlobalData.World;
			FVectorDouble fvectorDouble = info.EffectSpawnPosition.ToUeVector(false);
			FTransformDouble? ftransformDouble = new FTransformDouble?(new FTransformDouble(ref Rotator.ZeroRotator, ref fvectorDouble, ref Vector.OneVector));
			Func<int, bool> <>9__1;
			instance.SpawnEffect(world, ftransformDouble, effectPath, "[CheckPointEffectController.CreateTrackEffect]", null, EEffectType.Scene, null, delegate(ELoadEffectResult result, int handle)
			{
				if (result != ELoadEffectResult.Success)
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module = ELogModule.GeneralLogicTree;
					ELogAuthor author = ELogAuthor.YSQ;
					string message = "GeneralLogicTree:CheckPointEffectController.SpawnEffect 错误";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("result", result);
					instance2.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					return;
				}
				if (handle == 0)
				{
					return;
				}
				if (this.EffectHandles.ContainsKey(nodeId))
				{
					this.StopEffect(nodeId);
				}
				this.EffectHandles[nodeId] = handle;
				EffectSystem instance3 = Singleton<EffectSystem>.Instance;
				Func<int, bool> func;
				if ((func = <>9__1) == null)
				{
					func = (<>9__1 = ((int _) => this.EffectHandles.ContainsKey(nodeId)));
				}
				instance3.RegisterCustomCheckOwnerFunc(handle, func);
			}, null, false, false);
		}

		// Token: 0x0603C065 RID: 245861 RVA: 0x00F39CFC File Offset: 0x00F37EFC
		public void StopEffect(int nodeId)
		{
			int num;
			if (this.EffectHandles.Remove(nodeId, out num) && Singleton<EffectSystem>.Instance.IsValid(num))
			{
				Singleton<EffectSystem>.Instance.StopEffectById(num, "[CheckPointEffectController.End]", true, null);
			}
		}

		// Token: 0x04021B81 RID: 138113
		[CompilerGenerated]
		private Blackboard <Blackboard>P = Blackboard;

		// Token: 0x04021B82 RID: 138114
		private readonly Dictionary<int, CheckPointEffectController.CheckPointEffectInfo> EffectSpawnInfos = new Dictionary<int, CheckPointEffectController.CheckPointEffectInfo>();

		// Token: 0x04021B83 RID: 138115
		private readonly Dictionary<int, int> EffectHandles = new Dictionary<int, int>();

		// Token: 0x0200BD69 RID: 48489
		[Nullable(0)]
		private class CheckPointEffectInfo
		{
			// Token: 0x0403A585 RID: 238981
			public string EffectPathKey = "";

			// Token: 0x0403A586 RID: 238982
			public Vector EffectSpawnPosition = Vector.ZeroVectorProxy;
		}
	}
}
