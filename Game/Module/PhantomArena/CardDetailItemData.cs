using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PhantomArena.Common.CardDetail;

namespace CSharpScript.Game.Module.PhantomArena
{
	// Token: 0x0200549E RID: 21662
	[NullableContext(2)]
	[Nullable(0)]
	[RequiredMember]
	public class CardDetailItemData
	{
		// Token: 0x060371BA RID: 225722 RVA: 0x00DFD9A4 File Offset: 0x00DFBBA4
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public CardDetailItemData()
		{
		}

		// Token: 0x0401FBB8 RID: 129976
		[Nullable(1)]
		[RequiredMember]
		public string Name;

		// Token: 0x0401FBB9 RID: 129977
		public ICardAttributeData AttributeData;

		// Token: 0x0401FBBA RID: 129978
		public ICardDescriptionData CardDescriptionData;

		// Token: 0x0401FBBB RID: 129979
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<CardDetailFactorDescItemData> FactorDataList;

		// Token: 0x0401FBBC RID: 129980
		public string BgDescription;

		// Token: 0x0401FBBD RID: 129981
		public ICardDetailTaskData TaskData;

		// Token: 0x0401FBBE RID: 129982
		public ICardDetailActiveSkillData ActiveSkillData;

		// Token: 0x0401FBBF RID: 129983
		public ICardDetailPassiveSkillData PassiveSkillData;

		// Token: 0x0401FBC0 RID: 129984
		public ICardDetailLockData LockData;

		// Token: 0x0401FBC1 RID: 129985
		public ICardDetailDurationData DurationData;

		// Token: 0x0401FBC2 RID: 129986
		public ICardDetailRemainRoundData RemainRoundData;
	}
}
