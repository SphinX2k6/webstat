using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.Module.InstanceDungeon.Define
{
	// Token: 0x02005C2F RID: 23599
	[NullableContext(1)]
	[Nullable(0)]
	public class PrewarFormationData
	{
		// Token: 0x0603BA44 RID: 244292 RVA: 0x00F1C734 File Offset: 0x00F1A934
		public int GetPlayerId()
		{
			return this.PlayerId;
		}

		// Token: 0x0603BA45 RID: 244293 RVA: 0x00F1C73C File Offset: 0x00F1A93C
		public void SetPlayerId(int value)
		{
			this.PlayerId = value;
		}

		// Token: 0x0603BA46 RID: 244294 RVA: 0x00F1C745 File Offset: 0x00F1A945
		public int GetConfigId()
		{
			return this.ConfigId;
		}

		// Token: 0x0603BA47 RID: 244295 RVA: 0x00F1C74D File Offset: 0x00F1A94D
		public void SetConfigId(int value)
		{
			this.ConfigId = value;
		}

		// Token: 0x0603BA48 RID: 244296 RVA: 0x00F1C756 File Offset: 0x00F1A956
		public int GetSkinId()
		{
			return this.SkinId;
		}

		// Token: 0x0603BA49 RID: 244297 RVA: 0x00F1C75E File Offset: 0x00F1A95E
		public void SetSkinId(int value)
		{
			this.SkinId = value;
		}

		// Token: 0x0603BA4A RID: 244298 RVA: 0x00F1C767 File Offset: 0x00F1A967
		public bool IsEmpty()
		{
			return this.ConfigId == 0;
		}

		// Token: 0x0603BA4B RID: 244299 RVA: 0x00F1C774 File Offset: 0x00F1A974
		public bool IsLeader()
		{
			int playerId = this.PlayerId;
			MatchTeamInfo matchTeamInfo = ModelBase<InstanceDungeonModel>.Instance.GetMatchTeamInfo();
			int? num = (matchTeamInfo != null) ? new int?(matchTeamInfo.HostId) : null;
			return playerId == num.GetValueOrDefault() & num != null;
		}

		// Token: 0x0603BA4C RID: 244300 RVA: 0x00F1C7BC File Offset: 0x00F1A9BC
		public bool IsSelf()
		{
			return this.PlayerId == ModelBase<CreatureModel>.Instance.GetPlayerId();
		}

		// Token: 0x0603BA4D RID: 244301 RVA: 0x00F1C7D0 File Offset: 0x00F1A9D0
		public int GetLevel()
		{
			return this.Level;
		}

		// Token: 0x0603BA4E RID: 244302 RVA: 0x00F1C7D8 File Offset: 0x00F1A9D8
		public void SetLevel(int value)
		{
			this.Level = value;
		}

		// Token: 0x0603BA4F RID: 244303 RVA: 0x00F1C7E1 File Offset: 0x00F1A9E1
		public bool GetIsReady()
		{
			return this.IsReady;
		}

		// Token: 0x0603BA50 RID: 244304 RVA: 0x00F1C7E9 File Offset: 0x00F1A9E9
		public void SetIsReady(bool value)
		{
			this.IsReady = value;
		}

		// Token: 0x0603BA51 RID: 244305 RVA: 0x00F1C7F2 File Offset: 0x00F1A9F2
		public string GetPlayerName()
		{
			return ModelBase<InstanceDungeonModel>.Instance.GetMatchTeamName(this.PlayerId) ?? "";
		}

		// Token: 0x0603BA52 RID: 244306 RVA: 0x00F1C80D File Offset: 0x00F1AA0D
		public string GetPlayerOnlineId()
		{
			return ModelBase<InstanceDungeonModel>.Instance.GetMatchTeamOnlineId(this.PlayerId) ?? "";
		}

		// Token: 0x0603BA53 RID: 244307 RVA: 0x00F1C828 File Offset: 0x00F1AA28
		public void SetOnlineNumber(int onlineNumber)
		{
			this.OnlineNumber = onlineNumber;
		}

		// Token: 0x0603BA54 RID: 244308 RVA: 0x00F1C831 File Offset: 0x00F1AA31
		public int GetOnlineNumber()
		{
			return this.OnlineNumber;
		}

		// Token: 0x0603BA55 RID: 244309 RVA: 0x00F1C839 File Offset: 0x00F1AA39
		public int GetLife()
		{
			return this.Life;
		}

		// Token: 0x0603BA56 RID: 244310 RVA: 0x00F1C841 File Offset: 0x00F1AA41
		public void SetLife(int value)
		{
			this.Life = value;
		}

		// Token: 0x0603BA57 RID: 244311 RVA: 0x00F1C84A File Offset: 0x00F1AA4A
		public int GetMaxLife()
		{
			return this.MaxLife;
		}

		// Token: 0x0603BA58 RID: 244312 RVA: 0x00F1C852 File Offset: 0x00F1AA52
		public void SetMaxLife(int value)
		{
			this.MaxLife = value;
		}

		// Token: 0x0603BA59 RID: 244313 RVA: 0x00F1C85B File Offset: 0x00F1AA5B
		public int GetIndex()
		{
			return this.Index;
		}

		// Token: 0x0603BA5A RID: 244314 RVA: 0x00F1C863 File Offset: 0x00F1AA63
		public void SetIndex(int value)
		{
			this.Index = value;
		}

		// Token: 0x0603BA5B RID: 244315 RVA: 0x00F1C86C File Offset: 0x00F1AA6C
		public int GetMultiSkillBranchId()
		{
			return this.MultiSkillBranchId;
		}

		// Token: 0x0603BA5C RID: 244316 RVA: 0x00F1C874 File Offset: 0x00F1AA74
		public void SetMultiSkillBranchId(int value)
		{
			this.MultiSkillBranchId = value;
		}

		// Token: 0x040218E5 RID: 137445
		private int PlayerId;

		// Token: 0x040218E6 RID: 137446
		private int ConfigId;

		// Token: 0x040218E7 RID: 137447
		private int SkinId;

		// Token: 0x040218E8 RID: 137448
		private int Level;

		// Token: 0x040218E9 RID: 137449
		private bool IsReady;

		// Token: 0x040218EA RID: 137450
		private int OnlineNumber = -1;

		// Token: 0x040218EB RID: 137451
		private int Life;

		// Token: 0x040218EC RID: 137452
		private int MaxLife = 1;

		// Token: 0x040218ED RID: 137453
		private int Index;

		// Token: 0x040218EE RID: 137454
		private int MultiSkillBranchId;
	}
}
