using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.NewWorld.SceneItem.Model
{
	// Token: 0x02004848 RID: 18504
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	internal class ShootTargetModel : ModelBase<ShootTargetModel>
	{
		// Token: 0x06030234 RID: 197172 RVA: 0x00BACDBA File Offset: 0x00BAAFBA
		protected override bool OnInit()
		{
			return true;
		}

		// Token: 0x06030235 RID: 197173 RVA: 0x00BACDBD File Offset: 0x00BAAFBD
		public void AddTarget(int entityId, int groupId)
		{
		}

		// Token: 0x06030236 RID: 197174 RVA: 0x00BACDBF File Offset: 0x00BAAFBF
		public void RemoveTarget(int entityId)
		{
		}

		// Token: 0x06030237 RID: 197175 RVA: 0x00BACDC1 File Offset: 0x00BAAFC1
		protected override bool OnClear()
		{
			return true;
		}
	}
}
