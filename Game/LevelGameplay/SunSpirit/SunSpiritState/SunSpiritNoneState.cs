using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.LevelGamePlay.SunSpirit.SunSpiritPerform;

namespace CSharpScript.Game.LevelGamePlay.SunSpirit.SunSpiritState
{
	// Token: 0x02006AAC RID: 27308
	public class SunSpiritNoneState : SunSpiritBaseState
	{
		// Token: 0x0604386D RID: 276589 RVA: 0x011688A3 File Offset: 0x01166AA3
		[NullableContext(1)]
		public SunSpiritNoneState(SunSpiritData sunSpiritData) : base(ESunSpiritStateType.None, sunSpiritData)
		{
		}

		// Token: 0x0604386E RID: 276590 RVA: 0x011688B0 File Offset: 0x01166AB0
		protected override bool OnEnter()
		{
			if (!(this.SunSpiritData.GetSunSpiritPerform() is SunSpiritNonePerform))
			{
				Transform transform = Transform.Create();
				((ISunSpiritScenePerform)this.SunSpiritData.GetSunSpiritPerform()).GetTransform(transform);
				this.SunSpiritData.ChangeSunSpiritPerform(new SunSpiritNonePerform(this.SunSpiritData, transform));
			}
			return true;
		}
	}
}
