using System;
using System.Collections.Generic;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Item
{
	// Token: 0x020068EB RID: 26859
	public class DropCatchRoleBarItem : GridProxyAbstract<int>
	{
		// Token: 0x06042BFC RID: 273404 RVA: 0x011217AE File Offset: 0x0111F9AE
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUISprite))
			};
		}

		// Token: 0x06042BFD RID: 273405 RVA: 0x011217D1 File Offset: 0x0111F9D1
		public override void Refresh(int data, bool isSelected, int gridIndex)
		{
		}

		// Token: 0x06042BFE RID: 273406 RVA: 0x011217D3 File Offset: 0x0111F9D3
		public override UniTask RefreshAsync(int data, bool isSelected, int gridIndex)
		{
			return UniTask.CompletedTask;
		}
	}
}
