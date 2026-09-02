using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.SkillButtonUi.Custom
{
	// Token: 0x02004F9A RID: 20378
	[NullableContext(1)]
	[Nullable(0)]
	public class SkillButtonCustomHandleBase
	{
		// Token: 0x060349BE RID: 215486 RVA: 0x00D32952 File Offset: 0x00D30B52
		public void Init(SkillButtonData skillButtonData)
		{
			this.SkillButtonData = skillButtonData;
			this.OnInit();
		}

		// Token: 0x060349BF RID: 215487 RVA: 0x00D32961 File Offset: 0x00D30B61
		protected virtual void OnInit()
		{
		}

		// Token: 0x060349C0 RID: 215488 RVA: 0x00D32963 File Offset: 0x00D30B63
		public virtual void Refresh()
		{
		}

		// Token: 0x060349C1 RID: 215489 RVA: 0x00D32965 File Offset: 0x00D30B65
		public virtual void RefreshByTagChanged()
		{
		}

		// Token: 0x060349C2 RID: 215490 RVA: 0x00D32967 File Offset: 0x00D30B67
		public virtual bool RefreshOnInputControllerChange()
		{
			return false;
		}

		// Token: 0x060349C3 RID: 215491 RVA: 0x00D3296A File Offset: 0x00D30B6A
		public void ClearModifyMark()
		{
			this.SkillCdModifyMark = false;
			this.EnableModifyMark = false;
		}

		// Token: 0x060349C4 RID: 215492 RVA: 0x00D3297A File Offset: 0x00D30B7A
		public virtual float GetCustomRemainingCoolDown()
		{
			return 0f;
		}

		// Token: 0x0401E550 RID: 124240
		public ESkillButtonCustomHandle HandleType;

		// Token: 0x0401E551 RID: 124241
		[Nullable(2)]
		protected SkillButtonData SkillButtonData;

		// Token: 0x0401E552 RID: 124242
		public List<int> TagIds = new List<int>();

		// Token: 0x0401E553 RID: 124243
		public List<long> BuffIds = new List<long>();

		// Token: 0x0401E554 RID: 124244
		public List<string> Params = new List<string>();

		// Token: 0x0401E555 RID: 124245
		public bool ForceEnable;

		// Token: 0x0401E556 RID: 124246
		public bool SkillCdModifyMark;

		// Token: 0x0401E557 RID: 124247
		public bool EnableModifyMark;

		// Token: 0x0401E558 RID: 124248
		public bool CustomHdModifyMark;

		// Token: 0x0401E559 RID: 124249
		public int CustomHdMarkFrom = -1;
	}
}
