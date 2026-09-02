using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Fight.Struct;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Abilities.Follow
{
	// Token: 0x02004967 RID: 18791
	[NullableContext(1)]
	[Nullable(0)]
	public class TagModifier
	{
		// Token: 0x06031213 RID: 201235 RVA: 0x00C3A8CC File Offset: 0x00C38ACC
		public static TagModifier Create(SFollowShooterTagConfig config, Dictionary<int, HashSet<int>> listenTagToCheckIndexMap, int dataIndex)
		{
			TagModifier tagModifier = new TagModifier();
			foreach (FGameplayTag tag in config.AddTags.GameplayTags)
			{
				tagModifier.AddTagSet.Add(tag.TagId());
			}
			foreach (FGameplayTag tag2 in config.CheckTags.GameplayTags)
			{
				int num = tag2.TagId();
				HashSet<int> hashSet;
				if (!listenTagToCheckIndexMap.TryGetValue(num, out hashSet))
				{
					hashSet = new HashSet<int>();
					listenTagToCheckIndexMap[num] = hashSet;
				}
				hashSet.Add(dataIndex);
				tagModifier.CheckTagSet.Add(num);
			}
			tagModifier.CheckHasTag = config.CheckHasTag;
			tagModifier.CheckAll = (config.LogicType == ETagLogicType.All);
			return tagModifier;
		}

		// Token: 0x06031214 RID: 201236 RVA: 0x00C3A9C4 File Offset: 0x00C38BC4
		public void TriggerModifyTag([Nullable(2)] BaseTagComponent currentRoleTagComp, BaseTagComponent selfTagComp)
		{
			if (this.CheckNeedAdd(currentRoleTagComp))
			{
				if (!this.HasAddTag)
				{
					this.HasAddTag = true;
					foreach (int tagId in this.AddTagSet)
					{
						selfTagComp.TagContainer.UpdateExactTag(ETagChannel.Common, tagId, 1);
					}
				}
				return;
			}
			if (this.HasAddTag)
			{
				this.HasAddTag = false;
				foreach (int tagId2 in this.AddTagSet)
				{
					selfTagComp.TagContainer.UpdateExactTag(ETagChannel.Common, tagId2, -1);
				}
			}
		}

		// Token: 0x06031215 RID: 201237 RVA: 0x00C3AA90 File Offset: 0x00C38C90
		[NullableContext(2)]
		private bool CheckNeedAdd(BaseTagComponent currentRoleTagComp)
		{
			if (currentRoleTagComp == null)
			{
				return false;
			}
			bool flag = this.CheckAll ? currentRoleTagComp.HasAllTag(this.CheckTagSet) : currentRoleTagComp.HasAnyTag(this.CheckTagSet);
			if (!this.CheckHasTag)
			{
				return !flag;
			}
			return flag;
		}

		// Token: 0x0401C495 RID: 115861
		private readonly HashSet<int> AddTagSet = new HashSet<int>();

		// Token: 0x0401C496 RID: 115862
		private readonly HashSet<int> CheckTagSet = new HashSet<int>();

		// Token: 0x0401C497 RID: 115863
		private bool CheckHasTag;

		// Token: 0x0401C498 RID: 115864
		private bool CheckAll;

		// Token: 0x0401C499 RID: 115865
		private bool HasAddTag;
	}
}
