using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.GenericPrompt.View
{
	// Token: 0x02005CAF RID: 23727
	public class ChallengeWantedAchieveFloatTips : GenericPromptFloatTipsBase
	{
		// Token: 0x0603BE18 RID: 245272 RVA: 0x00F2CE08 File Offset: 0x00F2B008
		[NullableContext(1)]
		public ChallengeWantedAchieveFloatTips(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603BE19 RID: 245273 RVA: 0x00F2CE14 File Offset: 0x00F2B014
		protected override void SetMainText([ParamCollection] [Nullable(new byte[]
		{
			1,
			2
		})] IReadOnlyList<object> param)
		{
			UUIText text = base.GetText(0);
			IPromptParamHub data = this.Data;
			string value;
			if (data == null)
			{
				value = null;
			}
			else
			{
				TableTextArgNew mainTextObj = data.MainTextObj;
				value = ((mainTextObj != null) ? mainTextObj.TextKey : null);
			}
			if (!string.IsNullOrEmpty(value))
			{
				string configTextByKey = Singleton<PublicUtil>.Instance.GetConfigTextByKey(this.Data.MainTextObj.TextKey);
				if (!StringUtils.IsBlank(configTextByKey))
				{
					string[] array = new string[param.Count];
					for (int i = 0; i < param.Count; i++)
					{
						string[] array2 = array;
						int num = i;
						object obj = param[i];
						array2[num] = ((obj != null) ? obj.ToString() : null);
					}
					if (text != null)
					{
						text.SetText(StringUtils.Format(configTextByKey, array), true);
					}
					if (text != null)
					{
						text.SetUIActive(true);
						return;
					}
				}
				else
				{
					text.SetUIActive(false);
				}
				return;
			}
			if (!StringUtils.IsBlank(this.TypeConfig.Value.GeneralText))
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, this.TypeConfig.Value.GeneralText, param);
				if (text != null)
				{
					text.SetUIActive(true);
				}
				return;
			}
			if (text != null)
			{
				text.SetUIActive(false);
			}
		}

		// Token: 0x0603BE1A RID: 245274 RVA: 0x00F2CF18 File Offset: 0x00F2B118
		protected override void SetExtraText([ParamCollection] [Nullable(new byte[]
		{
			1,
			2
		})] IReadOnlyList<object> param)
		{
			UUIText text = base.GetText(1);
			IPromptParamHub data = this.Data;
			string value;
			if (data == null)
			{
				value = null;
			}
			else
			{
				TableTextArgNew extraTextObj = data.ExtraTextObj;
				value = ((extraTextObj != null) ? extraTextObj.TextKey : null);
			}
			if (!string.IsNullOrEmpty(value))
			{
				string configTextByKey = Singleton<PublicUtil>.Instance.GetConfigTextByKey(this.Data.ExtraTextObj.TextKey);
				if (!StringUtils.IsBlank(configTextByKey))
				{
					string[] array = new string[param.Count];
					for (int i = 0; i < param.Count; i++)
					{
						string[] array2 = array;
						int num = i;
						object obj = param[i];
						array2[num] = ((obj != null) ? obj.ToString() : null);
					}
					if (text != null)
					{
						text.SetText(StringUtils.Format(configTextByKey, array), true);
					}
					if (text != null)
					{
						text.SetUIActive(true);
						return;
					}
				}
				else
				{
					text.SetUIActive(false);
				}
				return;
			}
			if (!StringUtils.IsBlank(this.TypeConfig.Value.GeneralExtraText))
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, this.TypeConfig.Value.GeneralExtraText, param);
				if (text != null)
				{
					text.SetUIActive(true);
				}
				return;
			}
			if (text != null)
			{
				text.SetUIActive(false);
			}
		}
	}
}
