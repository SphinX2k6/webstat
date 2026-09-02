using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using UnrealEngine;

namespace CSharpScript.Game.Module.Plot.Sequence.NpcPerformState
{
	// Token: 0x0200539F RID: 21407
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class SeqNpcPerformStateManager : Singleton<SeqNpcPerformStateManager>
	{
		// Token: 0x0603695E RID: 223582 RVA: 0x00DCCCE2 File Offset: 0x00DCAEE2
		private void EnsureInit()
		{
			if (this.Initialized)
			{
				return;
			}
			this.Initialized = true;
			this.Register(new HoldingHandsSeqStateHandler());
			this.Register(new AssistedWalkSeqStateHandler());
			this.Register(new CancelAssistedWalkSeqStateHandler());
		}

		// Token: 0x0603695F RID: 223583 RVA: 0x00DCCD15 File Offset: 0x00DCAF15
		private void Register(SeqNpcPerformStateHandler handler)
		{
			this.CaptureHandlerMap[handler.PerformType] = handler;
			this.RestoreHandlerMap[handler.RelationType] = handler;
		}

		// Token: 0x06036960 RID: 223584 RVA: 0x00DCCD3C File Offset: 0x00DCAF3C
		[return: Nullable(2)]
		public NpcRelation Capture(ENpcGroupPerformType type, string key)
		{
			this.EnsureInit();
			SeqNpcPerformStateHandler seqNpcPerformStateHandler;
			if (!this.CaptureHandlerMap.TryGetValue(type, out seqNpcPerformStateHandler))
			{
				return null;
			}
			return seqNpcPerformStateHandler.Capture(key);
		}

		// Token: 0x06036961 RID: 223585 RVA: 0x00DCCD68 File Offset: 0x00DCAF68
		public void OnBattleCharacterHidden(string reason)
		{
			this.EnsureInit();
			SequenceModel instance = ModelBase<SequenceModel>.Instance;
			Dictionary<FName, NpcRelation> dictionary = (instance != null) ? instance.NpcRelationMap : null;
			if (dictionary == null)
			{
				return;
			}
			foreach (NpcRelation npcRelation in dictionary.Values)
			{
				SeqNpcPerformStateHandler seqNpcPerformStateHandler;
				if (this.RestoreHandlerMap.TryGetValue(npcRelation.RelationType, out seqNpcPerformStateHandler))
				{
					seqNpcPerformStateHandler.OnBattleCharacterHidden(npcRelation, reason);
				}
			}
		}

		// Token: 0x06036962 RID: 223586 RVA: 0x00DCCDF0 File Offset: 0x00DCAFF0
		public void Restore(NpcRelation relation, string reason)
		{
			this.EnsureInit();
			SeqNpcPerformStateHandler seqNpcPerformStateHandler;
			if (!this.RestoreHandlerMap.TryGetValue(relation.RelationType, out seqNpcPerformStateHandler))
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Plot;
				ELogAuthor author = ELogAuthor.HYF;
				string message = "[SeqNpcPerformState] Restore 未注册的关系类型";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("RelationType", relation.RelationType);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			seqNpcPerformStateHandler.Restore(relation, reason);
		}

		// Token: 0x0401F718 RID: 128792
		private readonly Dictionary<ENpcGroupPerformType, SeqNpcPerformStateHandler> CaptureHandlerMap = new Dictionary<ENpcGroupPerformType, SeqNpcPerformStateHandler>();

		// Token: 0x0401F719 RID: 128793
		private readonly Dictionary<ENpcRelationType, SeqNpcPerformStateHandler> RestoreHandlerMap = new Dictionary<ENpcRelationType, SeqNpcPerformStateHandler>();

		// Token: 0x0401F71A RID: 128794
		private bool Initialized;
	}
}
