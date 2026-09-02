using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Action;
using Google.Protobuf.Collections;

namespace CSharpScript.Game.LevelGamePlay.WriteLetter
{
	// Token: 0x02006A63 RID: 27235
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class WriteLetterModel : ModelBase<WriteLetterModel>
	{
		// Token: 0x060435F1 RID: 275953 RVA: 0x0115A45C File Offset: 0x0115865C
		public void SetLetterContentsFromProto([Nullable(new byte[]
		{
			2,
			1
		})] IReadOnlyList<MiniLetterContentPb> contents)
		{
			this.LetterContents.Clear();
			if (contents == null)
			{
				return;
			}
			foreach (MiniLetterContentPb miniLetterContentPb in contents)
			{
				int letterId = miniLetterContentPb.LetterId;
				HashSet<string> orCreateSet = this.GetOrCreateSet(letterId);
				RepeatedField<string> contentKey = miniLetterContentPb.ContentKey;
				if (contentKey != null)
				{
					foreach (string text in contentKey)
					{
						if (!string.IsNullOrEmpty(text))
						{
							orCreateSet.Add(text);
						}
					}
				}
			}
		}

		// Token: 0x060435F2 RID: 275954 RVA: 0x0115A50C File Offset: 0x0115870C
		public void ResetLetterContent(int letterId)
		{
			this.LetterContents.Remove(letterId);
		}

		// Token: 0x060435F3 RID: 275955 RVA: 0x0115A51C File Offset: 0x0115871C
		public bool RecordLetterContent(int letterId, ITalkItem talkItem)
		{
			string tidTalk = talkItem.TidTalk;
			if (string.IsNullOrEmpty(tidTalk))
			{
				return false;
			}
			HashSet<string> orCreateSet = this.GetOrCreateSet(letterId);
			if (orCreateSet.Contains(tidTalk))
			{
				return false;
			}
			orCreateSet.Add(tidTalk);
			return true;
		}

		// Token: 0x060435F4 RID: 275956 RVA: 0x0115A558 File Offset: 0x01158758
		public bool HasLetterContent(int letterId)
		{
			HashSet<string> hashSet;
			return this.LetterContents.TryGetValue(letterId, out hashSet) && hashSet != null && hashSet.Count > 0;
		}

		// Token: 0x060435F5 RID: 275957 RVA: 0x0115A588 File Offset: 0x01158788
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public IReadOnlySet<string> GetLetterContentKeys(int letterId)
		{
			HashSet<string> result;
			if (this.LetterContents.TryGetValue(letterId, out result))
			{
				return result;
			}
			return null;
		}

		// Token: 0x060435F6 RID: 275958 RVA: 0x0115A5A8 File Offset: 0x011587A8
		[NullableContext(2)]
		public MiniLetterContentPb GetLetterContentPb(int letterId)
		{
			HashSet<string> hashSet;
			if (!this.LetterContents.TryGetValue(letterId, out hashSet) || hashSet == null || hashSet.Count == 0)
			{
				return null;
			}
			MiniLetterContentPb miniLetterContentPb = MiniLetterContentPb.Create();
			miniLetterContentPb.LetterId = letterId;
			foreach (string item in hashSet)
			{
				miniLetterContentPb.ContentKey.Add(item);
			}
			return miniLetterContentPb;
		}

		// Token: 0x060435F7 RID: 275959 RVA: 0x0115A628 File Offset: 0x01158828
		protected override bool OnClear()
		{
			this.LetterContents.Clear();
			return true;
		}

		// Token: 0x060435F8 RID: 275960 RVA: 0x0115A638 File Offset: 0x01158838
		private HashSet<string> GetOrCreateSet(int letterId)
		{
			HashSet<string> hashSet;
			if (!this.LetterContents.TryGetValue(letterId, out hashSet) || hashSet == null)
			{
				hashSet = new HashSet<string>();
				this.LetterContents[letterId] = hashSet;
			}
			return hashSet;
		}

		// Token: 0x040259E0 RID: 154080
		private readonly Dictionary<int, HashSet<string>> LetterContents = new Dictionary<int, HashSet<string>>();
	}
}
