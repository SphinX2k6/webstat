using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.Module.GenericPrompt
{
	// Token: 0x02005CA2 RID: 23714
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Config(0)]
	public class GenericPromptConfig : ConfigBase<GenericPromptConfig>
	{
		// Token: 0x0603BDB9 RID: 245177 RVA: 0x00F2BF98 File Offset: 0x00F2A198
		public TableTextArgNew GetPromptTypeMainTextObj(int typeId)
		{
			return new TableTextArgNew(this.GetPromptTypeInfo(typeId).Value.GeneralText, Array.Empty<object>());
		}

		// Token: 0x0603BDBA RID: 245178 RVA: 0x00F2BFC8 File Offset: 0x00F2A1C8
		public FColor? GetPromptTypeMainTextColor(int typeId)
		{
			GenericPromptTypes? genericPromptTypes;
			string text = (this.GetPromptTypeInfo(typeId) != null) ? genericPromptTypes.GetValueOrDefault().TextColor : null;
			if (!string.IsNullOrEmpty(text))
			{
				return new FColor?(FColor.FromHex(text));
			}
			return null;
		}

		// Token: 0x0603BDBB RID: 245179 RVA: 0x00F2C018 File Offset: 0x00F2A218
		public TableTextArgNew GetPromptTypeExtraTextObj(int typeId)
		{
			return new TableTextArgNew(this.GetPromptTypeInfo(typeId).Value.GeneralExtraText, Array.Empty<object>());
		}

		// Token: 0x0603BDBC RID: 245180 RVA: 0x00F2C048 File Offset: 0x00F2A248
		public TableTextArgNew GetPromptMainTextObj(int promptId)
		{
			return new TableTextArgNew(this.GetPromptInfo(promptId).Value.TipsText, Array.Empty<object>());
		}

		// Token: 0x0603BDBD RID: 245181 RVA: 0x00F2C078 File Offset: 0x00F2A278
		public TableTextArgNew GetPromptExtraTextObj(int promptId)
		{
			return new TableTextArgNew(this.GetPromptInfo(promptId).Value.ExtraText, Array.Empty<object>());
		}

		// Token: 0x0603BDBE RID: 245182 RVA: 0x00F2C0A6 File Offset: 0x00F2A2A6
		public GenericPrompt? GetPromptInfo(int promptId)
		{
			return ConfigGenericPromptByTipsId.GetConfig(promptId.ToString(), true);
		}

		// Token: 0x0603BDBF RID: 245183 RVA: 0x00F2C0B5 File Offset: 0x00F2A2B5
		public GenericPrompt? GetPromptInfoByRawId(string promptRawId)
		{
			return ConfigGenericPromptByTipsId.GetConfig(promptRawId, true);
		}

		// Token: 0x0603BDC0 RID: 245184 RVA: 0x00F2C0C0 File Offset: 0x00F2A2C0
		public TableTextArgNew GetPromptMainTextObjByRawId(string promptRawId)
		{
			return new TableTextArgNew(this.GetPromptInfoByRawId(promptRawId).Value.TipsText, Array.Empty<object>());
		}

		// Token: 0x0603BDC1 RID: 245185 RVA: 0x00F2C0EE File Offset: 0x00F2A2EE
		public GenericPromptTypes? GetPromptTypeInfo(int typeId)
		{
			return ConfigGenericPromptTypesByTypeId.GetConfig(typeId, true);
		}

		// Token: 0x0603BDC2 RID: 245186 RVA: 0x00F2C0F8 File Offset: 0x00F2A2F8
		public int GetPriority(IPromptParamHub prompt)
		{
			if (prompt.PromptId == null)
			{
				return this.GetPromptTypeInfo(prompt.TypeId).Value.Priority;
			}
			int priority = this.GetPromptInfo(prompt.PromptId.Value).Value.Priority;
			if (priority == 0)
			{
				return this.GetPromptTypeInfo(prompt.TypeId).Value.Priority;
			}
			return priority;
		}
	}
}
