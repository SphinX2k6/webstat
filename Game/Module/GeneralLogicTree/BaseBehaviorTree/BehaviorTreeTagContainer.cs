using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.GeneralLogicTree.BaseBehaviorTree
{
	// Token: 0x02005CFC RID: 23804
	[NullableContext(1)]
	[Nullable(0)]
	public class BehaviorTreeTagContainer
	{
		// Token: 0x0603C007 RID: 245767 RVA: 0x00F379D8 File Offset: 0x00F35BD8
		public virtual void AddTag(EBehaviorTreeTag tag, string reason = "")
		{
			HashSet<string> hashSet;
			if (!this.Tags.TryGetValue(tag, out hashSet))
			{
				hashSet = (this.Tags[tag] = new HashSet<string>());
			}
			hashSet.Add(reason);
		}

		// Token: 0x0603C008 RID: 245768 RVA: 0x00F37A10 File Offset: 0x00F35C10
		public virtual void RemoveTag(EBehaviorTreeTag tag, string reason = "")
		{
			HashSet<string> hashSet;
			if (!this.Tags.TryGetValue(tag, out hashSet))
			{
				return;
			}
			hashSet.Remove(reason);
			if (hashSet.Count == 0)
			{
				this.Tags.Remove(tag);
			}
		}

		// Token: 0x0603C009 RID: 245769 RVA: 0x00F37A4B File Offset: 0x00F35C4B
		public bool ContainTag(EBehaviorTreeTag tag)
		{
			return this.Tags.ContainsKey(tag);
		}

		// Token: 0x04021B65 RID: 138085
		protected const string DEFAULET_REASON = "";

		// Token: 0x04021B66 RID: 138086
		private readonly Dictionary<EBehaviorTreeTag, HashSet<string>> Tags = new Dictionary<EBehaviorTreeTag, HashSet<string>>();
	}
}
