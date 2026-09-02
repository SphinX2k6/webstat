using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.InstanceDungeon.Define
{
	// Token: 0x02005C02 RID: 23554
	[NullableContext(1)]
	[Nullable(0)]
	public class InstanceBeInviteData
	{
		// Token: 0x0603B980 RID: 244096 RVA: 0x00F1B6D3 File Offset: 0x00F198D3
		public void SetPlayerId(int value)
		{
			this.PlayerId = value;
		}

		// Token: 0x0603B981 RID: 244097 RVA: 0x00F1B6DC File Offset: 0x00F198DC
		public int GetPlayerId()
		{
			return this.PlayerId;
		}

		// Token: 0x0603B982 RID: 244098 RVA: 0x00F1B6E4 File Offset: 0x00F198E4
		public void SetInstanceId(int value)
		{
			this.InstanceId = value;
		}

		// Token: 0x0603B983 RID: 244099 RVA: 0x00F1B6ED File Offset: 0x00F198ED
		public int GetInstanceId()
		{
			return this.InstanceId;
		}

		// Token: 0x0603B984 RID: 244100 RVA: 0x00F1B6F5 File Offset: 0x00F198F5
		public void SetName(string value)
		{
			this.Name = value;
		}

		// Token: 0x0603B985 RID: 244101 RVA: 0x00F1B6FE File Offset: 0x00F198FE
		public string GetName()
		{
			return this.Name;
		}

		// Token: 0x0603B986 RID: 244102 RVA: 0x00F1B706 File Offset: 0x00F19906
		public void SetLimitTimestamp(long value)
		{
			this.LimitTimestamp = value;
		}

		// Token: 0x0603B987 RID: 244103 RVA: 0x00F1B70F File Offset: 0x00F1990F
		public long GetLimitTimestamp()
		{
			return this.LimitTimestamp;
		}

		// Token: 0x0603B988 RID: 244104 RVA: 0x00F1B718 File Offset: 0x00F19918
		[NullableContext(2)]
		public string GetInstanceName()
		{
			InstanceDungeon? config = ConfigInstanceDungeonById.GetConfig(this.InstanceId, true);
			if (config != null)
			{
				return ConfigMultiTextLang.GetLocalTextNew(config.Value.MapName, null);
			}
			return null;
		}

		// Token: 0x040218A7 RID: 137383
		private int PlayerId;

		// Token: 0x040218A8 RID: 137384
		private int InstanceId;

		// Token: 0x040218A9 RID: 137385
		private string Name = "";

		// Token: 0x040218AA RID: 137386
		private long LimitTimestamp;
	}
}
