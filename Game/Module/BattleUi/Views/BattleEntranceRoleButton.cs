using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005FB9 RID: 24505
	public class BattleEntranceRoleButton : BattleEntranceButton
	{
		// Token: 0x0603D9E6 RID: 252390 RVA: 0x00FB29F6 File Offset: 0x00FB0BF6
		protected override void OnRegisterComponent()
		{
			base.OnRegisterComponent();
			this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(2, typeof(UUISprite)));
		}

		// Token: 0x0603D9E7 RID: 252391 RVA: 0x00FB2A19 File Offset: 0x00FB0C19
		[NullableContext(2)]
		public override void Initialize(object parameter = null)
		{
			base.Initialize(parameter);
			this.RefreshSpriteIconByFunctionType();
		}

		// Token: 0x0603D9E8 RID: 252392 RVA: 0x00FB2A28 File Offset: 0x00FB0C28
		private void RefreshSpriteIconByFunctionType()
		{
			if (this.FunctionType.GetValueOrDefault() == EFunctionType.Role)
			{
				string fightIconResonancePath = ConfigBase<FunctionConfig>.Instance.GetFightIconResonancePath();
				this.SetSpriteByPath(fightIconResonancePath, base.GetSprite(2), true, null, null);
			}
		}

		// Token: 0x0200C01B RID: 49179
		private enum EComponent
		{
			// Token: 0x0403B240 RID: 242240
			SpriteIcon = 2
		}
	}
}
