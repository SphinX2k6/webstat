using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.LevelGamePlay.OperationRestrict
{
	// Token: 0x02006B36 RID: 27446
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class InputTagModifyUtils : Singleton<InputTagModifyUtils>
	{
		// Token: 0x06043D20 RID: 277792 RVA: 0x01186E58 File Offset: 0x01185058
		private void InitTagInfoCache()
		{
			this.TagParentInfoCache.Clear();
			this.TagChildrenInfoCache.Clear();
			foreach (ValueTuple<string, string> valueTuple in InputDistributeDefine.InitializeInputDistributeTagDefine)
			{
				if (!(valueTuple.Item1 == "BlockAllInputTag"))
				{
					this.TagParentInfoCache[valueTuple.Item1] = valueTuple.Item2;
					HashSet<string> hashSet;
					if (valueTuple.Item2 == null || !this.TagChildrenInfoCache.TryGetValue(valueTuple.Item2, out hashSet))
					{
						hashSet = new HashSet<string>();
						string text = valueTuple.Item2 ?? "";
						this.TagChildrenInfoCache[text] = hashSet;
						if (string.IsNullOrEmpty(text))
						{
							Singleton<Log>.Instance.Warn(ELogModule.LevelEvent, ELogAuthor.LRX, "ParentTag of $" + valueTuple.Item1 + " is NullOrEmpty, possible overwriting other NullOrEmpty TagChildrenInfoCache!", default(ReadOnlySpan<ValueTuple<string, object>>));
						}
					}
					hashSet.Add(valueTuple.Item1);
				}
			}
		}

		// Token: 0x06043D21 RID: 277793 RVA: 0x01186F70 File Offset: 0x01185170
		private void GetAllChildInputTag(string inputTag, HashSet<string> childrenTagsContainer, bool bIncludeChildOfChild = false)
		{
			if (this.TagParentInfoCache.Count == 0 || this.TagChildrenInfoCache.Count > 0)
			{
				this.InitTagInfoCache();
			}
			HashSet<string> hashSet;
			if (!this.TagChildrenInfoCache.TryGetValue(inputTag, out hashSet) || hashSet.Count == 0)
			{
				return;
			}
			foreach (string item in hashSet)
			{
				childrenTagsContainer.Add(item);
			}
			if (bIncludeChildOfChild)
			{
				foreach (string inputTag2 in hashSet)
				{
					this.GetAllChildInputTag(inputTag2, childrenTagsContainer, true);
				}
			}
		}

		// Token: 0x06043D22 RID: 277794 RVA: 0x0118703C File Offset: 0x0118523C
		private void GetAllChildInputTag(string inputTag, List<string> childrenTagsContainer, bool bIncludeChildOfChild = false)
		{
			if (this.TagParentInfoCache.Count == 0 || this.TagChildrenInfoCache.Count > 0)
			{
				this.InitTagInfoCache();
			}
			HashSet<string> hashSet;
			if (!this.TagChildrenInfoCache.TryGetValue(inputTag, out hashSet) || hashSet.Count == 0)
			{
				return;
			}
			childrenTagsContainer.AddRange(hashSet);
			if (bIncludeChildOfChild)
			{
				foreach (string inputTag2 in hashSet)
				{
					this.GetAllChildInputTag(inputTag2, childrenTagsContainer, true);
				}
			}
		}

		// Token: 0x06043D23 RID: 277795 RVA: 0x011870D0 File Offset: 0x011852D0
		private string GetParentInputTag(string inputTag)
		{
			if (this.TagParentInfoCache.Count == 0 || this.TagChildrenInfoCache.Count > 0)
			{
				this.InitTagInfoCache();
			}
			string text;
			this.TagParentInfoCache.TryGetValue(inputTag, out text);
			return text ?? "";
		}

		// Token: 0x06043D24 RID: 277796 RVA: 0x01187118 File Offset: 0x01185318
		public bool GetIsInputTagEnable(IEnumerable<string> targetTagList, string tagToCheck, bool fullMatch = false)
		{
			if (this.TagParentInfoCache.Count == 0 || this.TagChildrenInfoCache.Count > 0)
			{
				this.InitTagInfoCache();
			}
			if (fullMatch)
			{
				return targetTagList.Contains(tagToCheck);
			}
			HashSet<string> hashSet = new HashSet<string>(targetTagList);
			string text = tagToCheck;
			while (text != null)
			{
				if (hashSet.Contains(text))
				{
					return true;
				}
				this.TagParentInfoCache.TryGetValue(text, out text);
			}
			return false;
		}

		// Token: 0x06043D25 RID: 277797 RVA: 0x0118717C File Offset: 0x0118537C
		private void ModifyInputTag(List<string> targetTagList, string[] tagsToAdd, string[] tagsToRem)
		{
			foreach (string item in tagsToRem)
			{
				int num = targetTagList.IndexOf(item);
				if (num != -1)
				{
					targetTagList.RemoveAt(num);
				}
			}
			foreach (string item2 in tagsToAdd)
			{
				if (targetTagList.IndexOf(item2) == -1)
				{
					targetTagList.Add(item2);
				}
			}
		}

		// Token: 0x06043D26 RID: 277798 RVA: 0x011871E4 File Offset: 0x011853E4
		private void EnableInputTag(List<string> targetTagList, string targetTagName)
		{
			if (this.GetIsInputTagEnable(targetTagList, targetTagName, false))
			{
				return;
			}
			string parentInputTag = this.GetParentInputTag(targetTagName);
			HashSet<string> hashSet = new HashSet<string>();
			this.GetAllChildInputTag(parentInputTag, hashSet, false);
			HashSet<string> hashSet2 = new HashSet<string>();
			this.GetAllChildInputTag(targetTagName, hashSet2, true);
			this.ModifyInputTag(targetTagList, new string[]
			{
				targetTagName
			}, hashSet2.ToArray<string>());
			int num = 0;
			foreach (string item in targetTagList)
			{
				if (hashSet.Contains(item))
				{
					num++;
				}
			}
			if (num == hashSet.Count && parentInputTag != null)
			{
				this.EnableInputTag(targetTagList, parentInputTag);
			}
		}

		// Token: 0x06043D27 RID: 277799 RVA: 0x0118729C File Offset: 0x0118549C
		private void DisableInputTag(List<string> targetTagList, string targetTagName)
		{
			if (!this.GetIsInputTagEnable(targetTagList, targetTagName, false))
			{
				return;
			}
			string parentInputTag = this.GetParentInputTag(targetTagName);
			HashSet<string> hashSet = new HashSet<string>();
			this.GetAllChildInputTag(parentInputTag, hashSet, false);
			HashSet<string> hashSet2 = new HashSet<string>();
			this.GetAllChildInputTag(targetTagName, hashSet2, true);
			List<string> list = new List<string>
			{
				targetTagName
			};
			list.AddRange(hashSet2);
			this.ModifyInputTag(targetTagList, Array.Empty<string>(), list.ToArray());
			List<string> list2 = new List<string>();
			foreach (string text in hashSet)
			{
				if (!(text == targetTagName) && this.GetIsInputTagEnable(targetTagList, text, false))
				{
					list2.Add(text);
				}
			}
			if (parentInputTag != null)
			{
				this.DisableInputTag(targetTagList, parentInputTag);
			}
			foreach (string targetTagName2 in list2)
			{
				this.EnableInputTag(targetTagList, targetTagName2);
			}
		}

		// Token: 0x06043D28 RID: 277800 RVA: 0x011873B0 File Offset: 0x011855B0
		public void SetEnableInputTag(List<string> targetTagList, string targetTagName, bool enable)
		{
			if (enable)
			{
				this.EnableInputTag(targetTagList, targetTagName);
				return;
			}
			this.DisableInputTag(targetTagList, targetTagName);
		}

		// Token: 0x04025EF1 RID: 155377
		[Nullable(new byte[]
		{
			1,
			1,
			2
		})]
		private readonly Dictionary<string, string> TagParentInfoCache = new Dictionary<string, string>();

		// Token: 0x04025EF2 RID: 155378
		private readonly Dictionary<string, HashSet<string>> TagChildrenInfoCache = new Dictionary<string, HashSet<string>>();
	}
}
