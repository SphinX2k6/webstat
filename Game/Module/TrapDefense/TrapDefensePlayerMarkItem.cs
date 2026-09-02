using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004DBA RID: 19898
	[NullableContext(1)]
	[Nullable(0)]
	public class TrapDefensePlayerMarkItem : TrapDefenseMarkItem
	{
		// Token: 0x06033896 RID: 211094 RVA: 0x00CE3891 File Offset: 0x00CE1A91
		[NullableContext(2)]
		public TrapDefensePlayerMarkItem(int markId, object extraParam = null) : base(markId, extraParam)
		{
		}

		// Token: 0x06033897 RID: 211095 RVA: 0x00CE389B File Offset: 0x00CE1A9B
		protected override void OnInitialize()
		{
		}

		// Token: 0x1700882E RID: 34862
		// (get) Token: 0x06033898 RID: 211096 RVA: 0x00CE389D File Offset: 0x00CE1A9D
		public override TrapDefenseDefine.ETrapDefenseMarkType MarkType
		{
			get
			{
				return TrapDefenseDefine.ETrapDefenseMarkType.Player;
			}
		}

		// Token: 0x1700882F RID: 34863
		// (get) Token: 0x06033899 RID: 211097 RVA: 0x00CE38A0 File Offset: 0x00CE1AA0
		public override Vector WorldPosition
		{
			get
			{
				return Singleton<GeneralLogicTreeUtil>.Instance.GetPlayerLocation() ?? Vector.ZeroVectorProxy;
			}
		}
	}
}
