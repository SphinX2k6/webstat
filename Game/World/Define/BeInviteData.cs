using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.World.Define
{
	// Token: 0x020046DB RID: 18139
	[NullableContext(1)]
	[Nullable(0)]
	public class BeInviteData
	{
		// Token: 0x0602F2B5 RID: 193205 RVA: 0x00B2CECF File Offset: 0x00B2B0CF
		public void SetPlayerId(int value)
		{
			this.PlayerId = value;
		}

		// Token: 0x0602F2B6 RID: 193206 RVA: 0x00B2CED8 File Offset: 0x00B2B0D8
		public int GetPlayerId()
		{
			return this.PlayerId;
		}

		// Token: 0x0602F2B7 RID: 193207 RVA: 0x00B2CEE0 File Offset: 0x00B2B0E0
		public void SetName(string value)
		{
			this.Name = value;
		}

		// Token: 0x0602F2B8 RID: 193208 RVA: 0x00B2CEE9 File Offset: 0x00B2B0E9
		public string GetName()
		{
			return this.Name;
		}

		// Token: 0x0602F2B9 RID: 193209 RVA: 0x00B2CEF1 File Offset: 0x00B2B0F1
		public void SetContent(string value)
		{
			this.Content = value;
		}

		// Token: 0x0602F2BA RID: 193210 RVA: 0x00B2CEFA File Offset: 0x00B2B0FA
		public string GetContent()
		{
			return this.Content;
		}

		// Token: 0x0602F2BB RID: 193211 RVA: 0x00B2CF02 File Offset: 0x00B2B102
		public void SetLimitTimestamp(long value)
		{
			this.LimitTimestamp = value;
		}

		// Token: 0x0602F2BC RID: 193212 RVA: 0x00B2CF0B File Offset: 0x00B2B10B
		public long GetLimitTimestamp()
		{
			return this.LimitTimestamp;
		}

		// Token: 0x0602F2BD RID: 193213 RVA: 0x00B2CF13 File Offset: 0x00B2B113
		public void SetToken(string value)
		{
			this.Token = value;
		}

		// Token: 0x0602F2BE RID: 193214 RVA: 0x00B2CF1C File Offset: 0x00B2B11C
		public string GetToken()
		{
			return this.Token;
		}

		// Token: 0x0602F2BF RID: 193215 RVA: 0x00B2CF24 File Offset: 0x00B2B124
		public void SetGameplayTagHash(long value)
		{
			this.GameplayTagHash = new long?(value);
		}

		// Token: 0x0602F2C0 RID: 193216 RVA: 0x00B2CF32 File Offset: 0x00B2B132
		public long? GetGameplayTagHash()
		{
			return this.GameplayTagHash;
		}

		// Token: 0x0401ADE3 RID: 110051
		private int PlayerId;

		// Token: 0x0401ADE4 RID: 110052
		private string Name = "";

		// Token: 0x0401ADE5 RID: 110053
		private string Content = "";

		// Token: 0x0401ADE6 RID: 110054
		private long LimitTimestamp;

		// Token: 0x0401ADE7 RID: 110055
		private string Token = "";

		// Token: 0x0401ADE8 RID: 110056
		private long? GameplayTagHash;
	}
}
