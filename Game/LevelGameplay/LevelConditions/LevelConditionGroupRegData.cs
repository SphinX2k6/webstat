using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006DDD RID: 28125
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelConditionGroupRegData
	{
		// Token: 0x06044608 RID: 280072 RVA: 0x011C3A60 File Offset: 0x011C1C60
		public LevelConditionGroupRegData(int conditionGroupId)
		{
			this.ConditionGroupId = conditionGroupId;
			ConditionGroup? config = ConfigConditionGroupById.GetConfig(this.ConditionGroupId, true);
			if (config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.LevelConditionRegistry;
				ELogAuthor author = ELogAuthor.TL;
				string message = "初始化事件条件组时, 找不到条件组配置";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("条件组Id", this.ConditionGroupId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			this.ConditionRelation = (config.Value.Relation == 1);
			for (int i = 0; i < config.Value.GroupIdLength; i++)
			{
				Condition? config2 = ConfigConditionById.GetConfig(config.Value.GroupId(i), true);
				if (config2 != null)
				{
					List<EEventName> conditionEventNames = Singleton<LevelConditionCenter>.Instance.GetConditionEventNames(config2.Value.Type);
					if (conditionEventNames.Count != 0)
					{
						this.ConditionRegDataSet.Add(new LevelConditionRegData(this, config2.Value, conditionEventNames));
					}
				}
			}
		}

		// Token: 0x06044609 RID: 280073 RVA: 0x011C3B6B File Offset: 0x011C1D6B
		public bool IsValid()
		{
			return this.ConditionRegDataSet.Count > 0;
		}

		// Token: 0x0604460A RID: 280074 RVA: 0x011C3B7C File Offset: 0x011C1D7C
		private void InvokeCallbacks()
		{
			foreach (ConditionPassCallback conditionPassCallback in this.ConditionPassCallbackSet)
			{
				TConditionPassCallback callback = conditionPassCallback.Callback;
				if (callback != null)
				{
					callback(conditionPassCallback.Params);
				}
			}
		}

		// Token: 0x0604460B RID: 280075 RVA: 0x011C3BE0 File Offset: 0x011C1DE0
		public void CheckReached()
		{
			if (this.ConditionRelation)
			{
				using (HashSet<LevelConditionRegData>.Enumerator enumerator = this.ConditionRegDataSet.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (enumerator.Current.ConditionReached)
						{
							this.InvokeCallbacks();
							break;
						}
					}
					return;
				}
			}
			using (HashSet<LevelConditionRegData>.Enumerator enumerator = this.ConditionRegDataSet.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (!enumerator.Current.ConditionReached)
					{
						return;
					}
				}
			}
			this.InvokeCallbacks();
		}

		// Token: 0x0604460C RID: 280076 RVA: 0x011C3C8C File Offset: 0x011C1E8C
		public void AddCallBack(ConditionPassCallback conditionPassCallback)
		{
			this.ConditionPassCallbackSet.Add(conditionPassCallback);
		}

		// Token: 0x0604460D RID: 280077 RVA: 0x011C3C9C File Offset: 0x011C1E9C
		public bool RemoveCallBack(ConditionPassCallback conditionPassCallback)
		{
			if (!this.ConditionPassCallbackSet.Remove(conditionPassCallback))
			{
				return false;
			}
			if (this.ConditionPassCallbackSet.Count > 0)
			{
				return false;
			}
			foreach (LevelConditionRegData levelConditionRegData in this.ConditionRegDataSet)
			{
				levelConditionRegData.Destroy();
				this.ConditionRegDataSet.Remove(levelConditionRegData);
			}
			return true;
		}

		// Token: 0x04026102 RID: 155906
		public readonly int ConditionGroupId;

		// Token: 0x04026103 RID: 155907
		private readonly bool ConditionRelation;

		// Token: 0x04026104 RID: 155908
		private readonly HashSet<LevelConditionRegData> ConditionRegDataSet = new HashSet<LevelConditionRegData>();

		// Token: 0x04026105 RID: 155909
		private readonly HashSet<ConditionPassCallback> ConditionPassCallbackSet = new HashSet<ConditionPassCallback>();
	}
}
