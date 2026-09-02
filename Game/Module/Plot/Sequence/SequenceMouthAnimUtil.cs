using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using UnrealEngine;

namespace CSharpScript.Game.Module.Plot.Sequence
{
	// Token: 0x0200538B RID: 21387
	[NullableContext(2)]
	[Nullable(0)]
	public static class SequenceMouthAnimUtil
	{
		// Token: 0x060368C2 RID: 223426 RVA: 0x00DC9E1B File Offset: 0x00DC801B
		public static string GetSequenceMouthAnimKey(ITalkItem talkItem)
		{
			if (!SequenceMouthAnimUtil.ShouldApplySequenceMouthAnim(talkItem))
			{
				return null;
			}
			if (!StringUtils.IsEmpty(talkItem.PlotLineKey))
			{
				return talkItem.PlotLineKey;
			}
			if (!StringUtils.IsEmpty(talkItem.TidTalk))
			{
				return talkItem.TidTalk;
			}
			return null;
		}

		// Token: 0x060368C3 RID: 223427 RVA: 0x00DC9E50 File Offset: 0x00DC8050
		[return: Nullable(1)]
		public static List<int> GetSequenceMouthAnimSpeakerIds(ITalkItem talkItem, TArray<int> unisonIdList = null)
		{
			List<int> list = new List<int>();
			SequenceMouthAnimUtil.AddMouthAnimSpeakerId(list, (talkItem != null) ? talkItem.WhoId : null);
			if (unisonIdList != null)
			{
				for (int i = 0; i < unisonIdList.Num(); i++)
				{
					SequenceMouthAnimUtil.AddMouthAnimSpeakerId(list, new int?(unisonIdList.Get(i)));
				}
			}
			return list;
		}

		// Token: 0x060368C4 RID: 223428 RVA: 0x00DC9EA4 File Offset: 0x00DC80A4
		private static bool ShouldApplySequenceMouthAnim(ITalkItem talkItem)
		{
			if (talkItem == null || !talkItem.PlayVoice.GetValueOrDefault())
			{
				return false;
			}
			ITalkItemDialog talkItemDialog = talkItem as ITalkItemDialog;
			if (talkItemDialog == null)
			{
				return true;
			}
			ITalkItemStyle style = talkItemDialog.Style;
			return (style == null || style.Type > ETalkItemStyle.InnerVoice) && !talkItemDialog.NoMouthAnim.GetValueOrDefault();
		}

		// Token: 0x060368C5 RID: 223429 RVA: 0x00DC9F04 File Offset: 0x00DC8104
		[NullableContext(1)]
		private static void AddMouthAnimSpeakerId(List<int> idList, int? id)
		{
			if (id != null)
			{
				int? num = id;
				int num2 = 0;
				if (!(num.GetValueOrDefault() <= num2 & num != null) && !idList.Contains(id.Value))
				{
					idList.Add(id.Value);
					return;
				}
			}
		}
	}
}
