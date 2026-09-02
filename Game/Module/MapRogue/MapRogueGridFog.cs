using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x02005973 RID: 22899
	public class MapRogueGridFog : UiPanelBase
	{
		// Token: 0x0603A04E RID: 237646 RVA: 0x00EAF175 File Offset: 0x00EAD375
		protected override void OnRegisterComponent()
		{
		}

		// Token: 0x0603A04F RID: 237647 RVA: 0x00EAF177 File Offset: 0x00EAD377
		protected override void OnStart()
		{
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
		}

		// Token: 0x0603A050 RID: 237648 RVA: 0x00EAF18C File Offset: 0x00EAD38C
		public void SetVision(bool bHasVision, bool bAnim)
		{
			if (this.HasVision == bHasVision)
			{
				return;
			}
			this.HasVision = bHasVision;
			if (bHasVision)
			{
				string[] array = new string[]
				{
					"Disappear",
					"Disappear1",
					"Disappear2"
				};
				int num = (int)Math.Floor(new Random().NextDouble() * (double)array.Length);
				CustomPromise<bool> stopPromise = new CustomPromise<bool>();
				this.LevelSequencePlayer.PlaySequenceAsync(array[num], stopPromise, false, false, null, false).ContinueWith(delegate()
				{
					this.SetActive(false);
				});
				return;
			}
			this.SetActive(true);
		}

		// Token: 0x04020E4F RID: 134735
		[Nullable(2)]
		protected LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x04020E50 RID: 134736
		private bool HasVision;
	}
}
