using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Fight.UI;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi
{
	// Token: 0x02005F89 RID: 24457
	public class BattleUiSpecialEnergyBarData
	{
		// Token: 0x0603D68A RID: 251530 RVA: 0x00F9F9A5 File Offset: 0x00F9DBA5
		public void Init()
		{
		}

		// Token: 0x0603D68B RID: 251531 RVA: 0x00F9F9A8 File Offset: 0x00F9DBA8
		public UniTask<bool> Preload()
		{
			BattleUiSpecialEnergyBarData.<Preload>d__8 <Preload>d__;
			<Preload>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<Preload>d__.<>4__this = this;
			<Preload>d__.<>1__state = -1;
			<Preload>d__.<>t__builder.Start<BattleUiSpecialEnergyBarData.<Preload>d__8>(ref <Preload>d__);
			return <Preload>d__.<>t__builder.Task;
		}

		// Token: 0x0603D68C RID: 251532 RVA: 0x00F9F9EB File Offset: 0x00F9DBEB
		public void OnLeaveLevel()
		{
			this.IsInit = false;
			this.IsLoading = false;
			this.DataTable = null;
			this.EnvironmentPropertyList.Clear();
			this.SpecialEnergyBarInfoMap.Clear();
		}

		// Token: 0x0603D68D RID: 251533 RVA: 0x00F9FA18 File Offset: 0x00F9DC18
		public void Clear()
		{
		}

		// Token: 0x0603D68E RID: 251534 RVA: 0x00F9FA1C File Offset: 0x00F9DC1C
		[NullableContext(2)]
		public SpecialEnergyBarInfo GetSpecialEnergyBarInfo(int id)
		{
			if (!this.IsInit)
			{
				return null;
			}
			SpecialEnergyBarInfo specialEnergyBarInfo;
			if (!this.SpecialEnergyBarInfoMap.TryGetValue(id, out specialEnergyBarInfo))
			{
				SSpecialEnergyBar dataTableRow = DataTableUtil.GetDataTableRow<SSpecialEnergyBar>(this.DataTable, id.ToString());
				specialEnergyBarInfo = new SpecialEnergyBarInfo();
				specialEnergyBarInfo.Init(id, dataTableRow);
				if (!GlobalData.IsPlayInEditor)
				{
					this.SpecialEnergyBarInfoMap[id] = specialEnergyBarInfo;
				}
			}
			return specialEnergyBarInfo;
		}

		// Token: 0x04022819 RID: 141337
		public bool IsOpenLog;

		// Token: 0x0402281A RID: 141338
		public bool IsSpecialEnergyBarEditorModeOpen;

		// Token: 0x0402281B RID: 141339
		[Nullable(2)]
		private UDataTable DataTable;

		// Token: 0x0402281C RID: 141340
		[Nullable(1)]
		public List<int> EnvironmentPropertyList = new List<int>();

		// Token: 0x0402281D RID: 141341
		[Nullable(1)]
		public Dictionary<int, SpecialEnergyBarInfo> SpecialEnergyBarInfoMap = new Dictionary<int, SpecialEnergyBarInfo>();

		// Token: 0x0402281E RID: 141342
		private bool IsInit;

		// Token: 0x0402281F RID: 141343
		private bool IsLoading;
	}
}
