using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Map.MapDefine
{
	// Token: 0x020058E4 RID: 22756
	[NullableContext(1)]
	[Nullable(0)]
	public class QuestMarkCreateInfo : DynamicMarkCreateInfo
	{
		// Token: 0x170093AA RID: 37802
		// (get) Token: 0x06039C03 RID: 236547 RVA: 0x00EA0750 File Offset: 0x00E9E950
		public long TreeId
		{
			get
			{
				return ((QuestMarkCreateParams)this.CreateParams).TreeId;
			}
		}

		// Token: 0x170093AB RID: 37803
		// (get) Token: 0x06039C04 RID: 236548 RVA: 0x00EA0762 File Offset: 0x00E9E962
		public int NodeId
		{
			get
			{
				return ((QuestMarkCreateParams)this.CreateParams).NodeId;
			}
		}

		// Token: 0x170093AC RID: 37804
		// (get) Token: 0x06039C05 RID: 236549 RVA: 0x00EA0774 File Offset: 0x00E9E974
		public bool IsBoundToParentQuest
		{
			get
			{
				return ((QuestMarkCreateParams)this.CreateParams).IsBoundToParentQuest.GetValueOrDefault();
			}
		}

		// Token: 0x06039C06 RID: 236550 RVA: 0x00EA078B File Offset: 0x00E9E98B
		public QuestMarkCreateInfo(QuestMarkCreateParams @params) : base(QuestMarkCreateInfo.PreprocessParams(@params))
		{
		}

		// Token: 0x06039C07 RID: 236551 RVA: 0x00EA0799 File Offset: 0x00E9E999
		private static QuestMarkCreateParams PreprocessParams(QuestMarkCreateParams @params)
		{
			if (@params.MapAndDungeonInfo != null)
			{
				@params.MapAndDungeonInfo.MapConfigId = @params.MapAndDungeonInfo.DungeonId;
			}
			return @params;
		}
	}
}
