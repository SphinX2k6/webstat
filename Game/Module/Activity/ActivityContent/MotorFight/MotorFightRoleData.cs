using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common;
using CSharpScript.Game.Module.RoleUi;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotorFight
{
	// Token: 0x020066C7 RID: 26311
	[NullableContext(1)]
	[Nullable(0)]
	public class MotorFightRoleData
	{
		// Token: 0x06041B59 RID: 269145 RVA: 0x010DA264 File Offset: 0x010D8464
		public MotorFightRoleData(MotorFightRole config)
		{
			this.Config = config;
		}

		// Token: 0x1700A072 RID: 41074
		// (get) Token: 0x06041B5B RID: 269147 RVA: 0x010DA27C File Offset: 0x010D847C
		// (set) Token: 0x06041B5A RID: 269146 RVA: 0x010DA273 File Offset: 0x010D8473
		public bool IsUnLock
		{
			get
			{
				return this.IsUnLockInternal;
			}
			set
			{
				this.IsUnLockInternal = value;
			}
		}

		// Token: 0x1700A073 RID: 41075
		// (get) Token: 0x06041B5C RID: 269148 RVA: 0x010DA284 File Offset: 0x010D8484
		public bool HasRedDot
		{
			get
			{
				if (!this.IsUnLock || this.ConditionId == 0)
				{
					return false;
				}
				HashSet<int> player = LocalStorage.GetPlayer<HashSet<int>>(ELocalStoragePlayerKey.MotorFightRoleClicked, null);
				return player == null || !player.Contains(this.Id);
			}
		}

		// Token: 0x06041B5D RID: 269149 RVA: 0x010DA2C4 File Offset: 0x010D84C4
		public void ReadRedDot()
		{
			if (!this.IsUnLock)
			{
				return;
			}
			HashSet<int> player = LocalStorage.GetPlayer<HashSet<int>>(ELocalStoragePlayerKey.MotorFightRoleClicked, null);
			if (player != null)
			{
				player.Add(this.Id);
				LocalStorage.SetPlayer<HashSet<int>>(ELocalStoragePlayerKey.MotorFightRoleClicked, player);
				return;
			}
			HashSet<int> value = new HashSet<int>
			{
				this.Id
			};
			LocalStorage.SetPlayer<HashSet<int>>(ELocalStoragePlayerKey.MotorFightRoleClicked, value);
		}

		// Token: 0x1700A074 RID: 41076
		// (get) Token: 0x06041B5E RID: 269150 RVA: 0x010DA322 File Offset: 0x010D8522
		public int Id
		{
			get
			{
				return this.Config.Id;
			}
		}

		// Token: 0x1700A075 RID: 41077
		// (get) Token: 0x06041B5F RID: 269151 RVA: 0x010DA330 File Offset: 0x010D8530
		public string RoleName
		{
			get
			{
				int trialRole = this.Config.TrialRole;
				RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(trialRole);
				if (roleConfig == null)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.MotorFightActivity;
					ELogAuthor author = ELogAuthor.CXJ;
					string message = "摩托战斗角色不存在";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("roleId", trialRole);
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					return "";
				}
				return roleConfig.Value.Name;
			}
		}

		// Token: 0x1700A076 RID: 41078
		// (get) Token: 0x06041B60 RID: 269152 RVA: 0x010DA3A2 File Offset: 0x010D85A2
		public int TrialRoleId
		{
			get
			{
				return this.Config.TrialRole;
			}
		}

		// Token: 0x1700A077 RID: 41079
		// (get) Token: 0x06041B61 RID: 269153 RVA: 0x010DA3AF File Offset: 0x010D85AF
		public string GenreDesc
		{
			get
			{
				return this.Config.GenreDesc;
			}
		}

		// Token: 0x1700A078 RID: 41080
		// (get) Token: 0x06041B62 RID: 269154 RVA: 0x010DA3BC File Offset: 0x010D85BC
		public string BuffName
		{
			get
			{
				return this.Config.BuffName;
			}
		}

		// Token: 0x1700A079 RID: 41081
		// (get) Token: 0x06041B63 RID: 269155 RVA: 0x010DA3C9 File Offset: 0x010D85C9
		public string BuffDesc
		{
			get
			{
				return this.Config.BuffDesc;
			}
		}

		// Token: 0x1700A07A RID: 41082
		// (get) Token: 0x06041B64 RID: 269156 RVA: 0x010DA3D6 File Offset: 0x010D85D6
		public string[] BuffDescParams
		{
			get
			{
				return this.Config.BuffDescParam();
			}
		}

		// Token: 0x1700A07B RID: 41083
		// (get) Token: 0x06041B65 RID: 269157 RVA: 0x010DA3E3 File Offset: 0x010D85E3
		public string RoleTexture
		{
			get
			{
				return this.Config.RolePicture;
			}
		}

		// Token: 0x1700A07C RID: 41084
		// (get) Token: 0x06041B66 RID: 269158 RVA: 0x010DA3F0 File Offset: 0x010D85F0
		public int ConditionId
		{
			get
			{
				return this.Config.UnlockCondition;
			}
		}

		// Token: 0x1700A07D RID: 41085
		// (get) Token: 0x06041B67 RID: 269159 RVA: 0x010DA3FD File Offset: 0x010D85FD
		public string AnimPath
		{
			get
			{
				return this.Config.MotorStandAnimPath;
			}
		}

		// Token: 0x04024AB8 RID: 150200
		private MotorFightRole Config;

		// Token: 0x04024AB9 RID: 150201
		private bool IsUnLockInternal;
	}
}
