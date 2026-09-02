using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Aki.Protocol.CombatMessage;
using CSharpScript.Core.Common;

namespace CSharpScript.Game.Module.CombatMessage
{
	// Token: 0x02005E95 RID: 24213
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class CombatMessageModel : ModelBase<CombatMessageModel>
	{
		// Token: 0x0603CE22 RID: 249378 RVA: 0x00F77418 File Offset: 0x00F75618
		protected override bool OnLeaveLevel()
		{
			this.AnyEntityInFight = false;
			return true;
		}

		// Token: 0x0603CE23 RID: 249379 RVA: 0x00F77422 File Offset: 0x00F75622
		protected override bool OnChangeMode()
		{
			this.AnyEntityInFight = false;
			return true;
		}

		// Token: 0x0603CE24 RID: 249380 RVA: 0x00F7742C File Offset: 0x00F7562C
		public bool AddMoveSync(IMoveSync moveSync)
		{
			return this.MoveSyncSet.Add(moveSync);
		}

		// Token: 0x0603CE25 RID: 249381 RVA: 0x00F7743F File Offset: 0x00F7563F
		public bool DeleteMoveSync(IMoveSync moveSync)
		{
			return this.MoveSyncSet.Remove(moveSync);
		}

		// Token: 0x0603CE26 RID: 249382 RVA: 0x00F77452 File Offset: 0x00F75652
		public void SetCombatMessageSwitch(bool isOpen)
		{
			this.CombatMessageSwitch = isOpen;
		}

		// Token: 0x0603CE27 RID: 249383 RVA: 0x00F7745C File Offset: 0x00F7565C
		public long GenMessageId()
		{
			long num = this.LastMessageId + 1L;
			this.LastMessageId = num;
			long num2 = num | this.Prefix << 60;
			if (this.CombatMessageSwitch)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.CombatInfo;
				ELogAuthor author = ELogAuthor.ZFJ;
				string message = "[GenMessageId]Debug";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("messageId", num2);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return num2;
		}

		// Token: 0x0603CE28 RID: 249384 RVA: 0x00F774BE File Offset: 0x00F756BE
		public void SetLastPrefix(int prefix)
		{
			this.Prefix = (long)prefix;
		}

		// Token: 0x0603CE29 RID: 249385 RVA: 0x00F774C8 File Offset: 0x00F756C8
		public void SetLastMessageId(long value)
		{
			this.LastMessageId = value;
		}

		// Token: 0x0603CE2A RID: 249386 RVA: 0x00F774D4 File Offset: 0x00F756D4
		[NullableContext(2)]
		public CombatMessageBuffer GetMessageBuffer(long creatureDataId)
		{
			if (creatureDataId == 0L)
			{
				return null;
			}
			CombatMessageBuffer combatMessageBuffer;
			if (!this.CombatMessageBufferMap.TryGetValue(creatureDataId, out combatMessageBuffer))
			{
				combatMessageBuffer = new CombatMessageBuffer(creatureDataId);
				this.CombatMessageBufferMap[creatureDataId] = combatMessageBuffer;
			}
			return combatMessageBuffer;
		}

		// Token: 0x0603CE2B RID: 249387 RVA: 0x00F7750C File Offset: 0x00F7570C
		[NullableContext(2)]
		public CombatMessageBuffer GetMessageBufferByEntityId(int entityId)
		{
			CombatMessageBuffer result;
			this.CombatMessageBufferMapByEntity.TryGetValue((long)entityId, out result);
			return result;
		}

		// Token: 0x0603CE2C RID: 249388 RVA: 0x00F7752C File Offset: 0x00F7572C
		public void SetEntityMap(int entityId, long creatureDataId)
		{
			CombatMessageBuffer value;
			if (this.CombatMessageBufferMap.TryGetValue(creatureDataId, out value))
			{
				this.CombatMessageBufferMapByEntity[(long)entityId] = value;
			}
		}

		// Token: 0x0603CE2D RID: 249389 RVA: 0x00F77558 File Offset: 0x00F75758
		public void TryClearSkillCount(long skillContextId)
		{
			int num;
			this.SkillContextMap.TryGetValue(skillContextId, out num);
			if (num == 0)
			{
				this.SkillContextMap.Remove(skillContextId);
				this.SkillHitCountMap.Remove(skillContextId);
				this.SkillHitCountByVictimMap.Remove(skillContextId);
				this.SkillDamageCountMap.Remove(skillContextId);
				this.SkillDamageCountByVictimMap.Remove(skillContextId);
			}
		}

		// Token: 0x0603CE2E RID: 249390 RVA: 0x00F775B8 File Offset: 0x00F757B8
		public void AddSkillRefCount(long? skillContextId)
		{
			if (skillContextId != null && skillContextId.Value > 0L)
			{
				int num;
				this.SkillContextMap.TryGetValue(skillContextId.Value, out num);
				this.SkillContextMap[skillContextId.Value] = num + 1;
				if (num == 0)
				{
					this.SkillHitCountMap[skillContextId.Value] = 0;
					this.SkillHitCountByVictimMap[skillContextId.Value] = new Dictionary<int, int>();
					this.SkillDamageCountMap[skillContextId.Value] = 0;
					this.SkillDamageCountByVictimMap[skillContextId.Value] = new Dictionary<int, int>();
				}
			}
		}

		// Token: 0x0603CE2F RID: 249391 RVA: 0x00F77660 File Offset: 0x00F75860
		public void RemoveSkillRefCount(long? skillContextId)
		{
			if (skillContextId != null && skillContextId.Value > 0L)
			{
				int num;
				if (!this.SkillContextMap.TryGetValue(skillContextId.Value, out num))
				{
					return;
				}
				num--;
				this.SkillContextMap[skillContextId.Value] = num;
				if (num <= 0)
				{
					this.SkillDirtySet.Add(skillContextId.Value);
				}
			}
		}

		// Token: 0x0603CE30 RID: 249392 RVA: 0x00F776C6 File Offset: 0x00F758C6
		public void OnBulletAdded(long? skillContextId, long? bulletContextId, string bulletRowName)
		{
			this.AddSkillRefCount(skillContextId);
			if (bulletContextId != null && bulletContextId.Value > 0L)
			{
				this.BulletDamageCountMap[bulletContextId.Value] = 0;
			}
		}

		// Token: 0x0603CE31 RID: 249393 RVA: 0x00F776F8 File Offset: 0x00F758F8
		public void OnBulletRemoved(long? skillContextId, long? bulletContextId)
		{
			this.RemoveSkillRefCount(skillContextId);
			if (bulletContextId != null && bulletContextId.Value > 0L)
			{
				TimerSystem.Instance.Delay(delegate(float _)
				{
					this.BulletDamageCountMap.Remove(bulletContextId.Value);
				}, 500f, null, null, true, 1f);
			}
		}

		// Token: 0x0603CE32 RID: 249394 RVA: 0x00F77760 File Offset: 0x00F75960
		[Conditional("DEBUG")]
		public void RecordDebugSkillContextInfo(long? skillContextId, int skillId)
		{
			if (!Singleton<Info>.Instance.IsBuildDevelopmentOrDebug)
			{
				return;
			}
			if (skillContextId == null || skillContextId.Value <= 0L)
			{
				return;
			}
			this.DebugSkillContextMap[skillContextId.Value] = (long)skillId;
		}

		// Token: 0x0603CE33 RID: 249395 RVA: 0x00F77798 File Offset: 0x00F75998
		[Conditional("DEBUG")]
		public void ClearDebugSkillContextInfo(long? skillContextId)
		{
			if (!Singleton<Info>.Instance.IsBuildDevelopmentOrDebug)
			{
				return;
			}
			if (skillContextId == null || skillContextId.Value <= 0L)
			{
				return;
			}
			TimerSystem.Instance.Delay(delegate(float _)
			{
				this.DebugSkillContextMap.Remove(skillContextId.Value);
			}, 500f, null, null, true, 1f);
		}

		// Token: 0x0603CE34 RID: 249396 RVA: 0x00F77807 File Offset: 0x00F75A07
		[Conditional("DEBUG")]
		public void RecordDebugBulletContextInfo(long? bulletContextId, string bulletRowName)
		{
			if (!Singleton<Info>.Instance.IsBuildDevelopmentOrDebug)
			{
				return;
			}
			if (bulletContextId == null || bulletContextId.Value <= 0L)
			{
				return;
			}
			this.DebugBulletContextMap[bulletContextId.Value] = bulletRowName;
		}

		// Token: 0x0603CE35 RID: 249397 RVA: 0x00F77840 File Offset: 0x00F75A40
		[Conditional("DEBUG")]
		public void ClearDebugBulletContextInfo(long bulletContextId)
		{
			if (!Singleton<Info>.Instance.IsBuildDevelopmentOrDebug)
			{
				return;
			}
			if (bulletContextId <= 0L)
			{
				return;
			}
			TimerSystem.Instance.Delay(delegate(float _)
			{
				this.DebugBulletContextMap.Remove(bulletContextId);
			}, 500f, null, null, true, 1f);
		}

		// Token: 0x0603CE36 RID: 249398 RVA: 0x00F778A0 File Offset: 0x00F75AA0
		public int? AddSkillHitCount(long? skillContextId)
		{
			if (skillContextId == null || skillContextId.Value <= 0L)
			{
				return null;
			}
			int num;
			if (!this.SkillHitCountMap.TryGetValue(skillContextId.Value, out num))
			{
				CombatLog instance = Singleton<CombatLog>.Instance;
				CombatLog.EDebugModule flag = CombatLog.EDebugModule.Message;
				Entity entity = null;
				string message = "技能命中计数器不存在";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("skillContextId", skillContextId);
				instance.Warn(flag, entity, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			this.SkillHitCountMap[skillContextId.Value] = num + 1;
			return new int?(num + 1);
		}

		// Token: 0x0603CE37 RID: 249399 RVA: 0x00F77934 File Offset: 0x00F75B34
		public int? AddSkillHitCountByVictim(long? skillContextId, int victimEntityId)
		{
			if (skillContextId == null || skillContextId.Value <= 0L)
			{
				return null;
			}
			Dictionary<int, int> dictionary;
			if (!this.SkillHitCountByVictimMap.TryGetValue(skillContextId.Value, out dictionary))
			{
				CombatLog instance = Singleton<CombatLog>.Instance;
				CombatLog.EDebugModule flag = CombatLog.EDebugModule.Message;
				Entity entity = null;
				string message = "技能对受害者命中计数器不存在";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("skillContextId", skillContextId);
				instance.Warn(flag, entity, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			int valueOrDefault = dictionary.GetValueOrDefault(victimEntityId, 0);
			dictionary[victimEntityId] = valueOrDefault + 1;
			return new int?(valueOrDefault + 1);
		}

		// Token: 0x0603CE38 RID: 249400 RVA: 0x00F779C8 File Offset: 0x00F75BC8
		public int? AddSkillDamageCount(long? skillContextId)
		{
			if (skillContextId == null || skillContextId.Value <= 0L)
			{
				return null;
			}
			int num;
			if (!this.SkillDamageCountMap.TryGetValue(skillContextId.Value, out num))
			{
				CombatLog instance = Singleton<CombatLog>.Instance;
				CombatLog.EDebugModule flag = CombatLog.EDebugModule.Message;
				Entity entity = null;
				string message = "技能伤害计数器不存在";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("skillContextId", skillContextId);
				instance.Warn(flag, entity, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			this.SkillDamageCountMap[skillContextId.Value] = num + 1;
			return new int?(num + 1);
		}

		// Token: 0x0603CE39 RID: 249401 RVA: 0x00F77A5C File Offset: 0x00F75C5C
		public int? AddSkillDamageCountByVictim(long? skillContextId, int victimEntityId)
		{
			if (skillContextId == null || skillContextId.Value <= 0L)
			{
				return null;
			}
			Dictionary<int, int> dictionary;
			if (!this.SkillDamageCountByVictimMap.TryGetValue(skillContextId.Value, out dictionary))
			{
				CombatLog instance = Singleton<CombatLog>.Instance;
				CombatLog.EDebugModule flag = CombatLog.EDebugModule.Message;
				Entity entity = null;
				string message = "技能对受害者伤害计数器不存在";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("skillContextId", skillContextId);
				instance.Warn(flag, entity, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			int valueOrDefault = dictionary.GetValueOrDefault(victimEntityId, 0);
			dictionary[victimEntityId] = valueOrDefault + 1;
			return new int?(valueOrDefault + 1);
		}

		// Token: 0x0603CE3A RID: 249402 RVA: 0x00F77AF0 File Offset: 0x00F75CF0
		public int? AddBulletDamageCount(long? bulletContextId)
		{
			if (bulletContextId == null || bulletContextId.Value <= 0L)
			{
				return null;
			}
			int num;
			if (!this.BulletDamageCountMap.TryGetValue(bulletContextId.Value, out num))
			{
				CombatLog instance = Singleton<CombatLog>.Instance;
				CombatLog.EDebugModule flag = CombatLog.EDebugModule.Message;
				Entity entity = null;
				string message = "子弹命中计数器不存在";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("bulletContextId", bulletContextId);
				instance.Warn(flag, entity, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			this.BulletDamageCountMap[bulletContextId.Value] = num + 1;
			return new int?(num + 1);
		}

		// Token: 0x040222D1 RID: 139985
		public const int COUNT_CONTEXT_REMOVE_DELAY = 500;

		// Token: 0x040222D2 RID: 139986
		public const float BUFFER_TIME_RATE = 1.05f;

		// Token: 0x040222D3 RID: 139987
		public const int TIME_BUFFER_SIZE = 20;

		// Token: 0x040222D4 RID: 139988
		public const float TIME_OFFSET_LERP_RATE = 0.1f;

		// Token: 0x040222D5 RID: 139989
		public const float FIX_BUFFER_TIME = 0.08f;

		// Token: 0x040222D6 RID: 139990
		public const int TIME_BUFFER_CHECK_COUNT_MIN = 5;

		// Token: 0x040222D7 RID: 139991
		public const float TIME_BUFFER_CHECK_TIME_MAX = 3f;

		// Token: 0x040222D8 RID: 139992
		public const float MAX_FLUCTUATE = 0.5f;

		// Token: 0x040222D9 RID: 139993
		public const float RECORD_UDP_MESSAGE_INTERNAL = 0.2f;

		// Token: 0x040222DA RID: 139994
		public const int MESSAGE_ID_MASK = 60;

		// Token: 0x040222DB RID: 139995
		public bool MoveSyncUdpMode = true;

		// Token: 0x040222DC RID: 139996
		public float MoveSyncUdpSendInterval = 0.03f;

		// Token: 0x040222DD RID: 139997
		public bool MoveSyncUdpFullSampling;

		// Token: 0x040222DE RID: 139998
		public bool CombatMessageSendPackMode = true;

		// Token: 0x040222DF RID: 139999
		public float CombatMessageSendInterval = 0.04f;

		// Token: 0x040222E0 RID: 140000
		public float CombatMessageSendIntervalMulti = 0.03f;

		// Token: 0x040222E1 RID: 140001
		public double CombatMessageSendLastTime;

		// Token: 0x040222E2 RID: 140002
		private long Prefix = 1L;

		// Token: 0x040222E3 RID: 140003
		private long LastMessageId;

		// Token: 0x040222E4 RID: 140004
		public readonly Dictionary<long, CombatMessageBuffer> CombatMessageBufferMap = new Dictionary<long, CombatMessageBuffer>();

		// Token: 0x040222E5 RID: 140005
		public readonly Dictionary<long, CombatMessageBuffer> CombatMessageBufferMapByEntity = new Dictionary<long, CombatMessageBuffer>();

		// Token: 0x040222E6 RID: 140006
		public bool NeedPushMove;

		// Token: 0x040222E7 RID: 140007
		public readonly HashSet<IMoveSync> MoveSyncSet = new HashSet<IMoveSync>();

		// Token: 0x040222E8 RID: 140008
		public bool AnyEntityInFight;

		// Token: 0x040222E9 RID: 140009
		public bool AnyHateChange;

		// Token: 0x040222EA RID: 140010
		public CombatSendPackRequest MessagePack = CombatSendPackRequest.Create();

		// Token: 0x040222EB RID: 140011
		private bool CombatMessageSwitch;

		// Token: 0x040222EC RID: 140012
		private readonly Dictionary<long, int> SkillContextMap = new Dictionary<long, int>();

		// Token: 0x040222ED RID: 140013
		private readonly Dictionary<long, int> SkillHitCountMap = new Dictionary<long, int>();

		// Token: 0x040222EE RID: 140014
		private readonly Dictionary<long, Dictionary<int, int>> SkillHitCountByVictimMap = new Dictionary<long, Dictionary<int, int>>();

		// Token: 0x040222EF RID: 140015
		private readonly Dictionary<long, int> SkillDamageCountMap = new Dictionary<long, int>();

		// Token: 0x040222F0 RID: 140016
		private readonly Dictionary<long, Dictionary<int, int>> SkillDamageCountByVictimMap = new Dictionary<long, Dictionary<int, int>>();

		// Token: 0x040222F1 RID: 140017
		private readonly Dictionary<long, int> BulletDamageCountMap = new Dictionary<long, int>();

		// Token: 0x040222F2 RID: 140018
		public readonly HashSet<long> SkillDirtySet = new HashSet<long>();

		// Token: 0x040222F3 RID: 140019
		private readonly Dictionary<long, long> DebugSkillContextMap = new Dictionary<long, long>();

		// Token: 0x040222F4 RID: 140020
		private readonly Dictionary<long, string> DebugBulletContextMap = new Dictionary<long, string>();
	}
}
