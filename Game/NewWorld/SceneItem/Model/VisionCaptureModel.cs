using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.NewWorld.SceneItem.Model
{
	// Token: 0x02004849 RID: 18505
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class VisionCaptureModel : ModelBase<VisionCaptureModel>
	{
		// Token: 0x06030239 RID: 197177 RVA: 0x00BACDCC File Offset: 0x00BAAFCC
		protected override bool OnInit()
		{
			this.VisionCache = new Dictionary<int, int>();
			this.VisionFinishCache = new Dictionary<int, int>();
			this.VisionEntityIdsCache = new Dictionary<int, bool>();
			return true;
		}

		// Token: 0x0603023A RID: 197178 RVA: 0x00BACDF0 File Offset: 0x00BAAFF0
		public void AddVisionCapture(int ownerId, int entityId)
		{
			if (ownerId != 0)
			{
				if (this.VisionCache.ContainsKey(ownerId))
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.SceneGameplay;
					ELogAuthor author = ELogAuthor.YZH;
					string message = "[VisionCaptureModel]重复添加收服声骸";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Capture Owner ID:", ownerId);
					instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
				this.VisionCache[ownerId] = entityId;
			}
			this.VisionEntityIdsCache[entityId] = true;
		}

		// Token: 0x0603023B RID: 197179 RVA: 0x00BACE53 File Offset: 0x00BAB053
		public void AddVisionCaptureFinish(int ownerId, int entityId)
		{
			if (ownerId != 0)
			{
				this.VisionFinishCache[ownerId] = entityId;
			}
		}

		// Token: 0x0603023C RID: 197180 RVA: 0x00BACE65 File Offset: 0x00BAB065
		public void RemoveVisionCapture(int ownerId, int entityId = 0)
		{
			if (ownerId != 0)
			{
				this.VisionCache.Remove(ownerId);
				this.VisionFinishCache.Remove(ownerId);
			}
			this.VisionEntityIdsCache.Remove(entityId);
		}

		// Token: 0x0603023D RID: 197181 RVA: 0x00BACE91 File Offset: 0x00BAB091
		public int GetVisionCapture(int ownerId)
		{
			return this.VisionCache[ownerId];
		}

		// Token: 0x0603023E RID: 197182 RVA: 0x00BACE9F File Offset: 0x00BAB09F
		[NullableContext(1)]
		public Dictionary<int, int> GetVisionFinish()
		{
			return this.VisionFinishCache;
		}

		// Token: 0x17008268 RID: 33384
		// (get) Token: 0x0603023F RID: 197183 RVA: 0x00BACEA7 File Offset: 0x00BAB0A7
		public Dictionary<int, bool> AllVisionEntityIds
		{
			get
			{
				return this.VisionEntityIdsCache;
			}
		}

		// Token: 0x06030240 RID: 197184 RVA: 0x00BACEAF File Offset: 0x00BAB0AF
		protected override bool OnClear()
		{
			this.VisionCache = null;
			Dictionary<int, int> visionFinishCache = this.VisionFinishCache;
			if (visionFinishCache != null)
			{
				visionFinishCache.Clear();
			}
			this.VisionFinishCache = null;
			Dictionary<int, bool> visionEntityIdsCache = this.VisionEntityIdsCache;
			if (visionEntityIdsCache != null)
			{
				visionEntityIdsCache.Clear();
			}
			this.VisionEntityIdsCache = null;
			return true;
		}

		// Token: 0x0401BA1B RID: 113179
		private Dictionary<int, int> VisionCache;

		// Token: 0x0401BA1C RID: 113180
		private Dictionary<int, int> VisionFinishCache;

		// Token: 0x0401BA1D RID: 113181
		private Dictionary<int, bool> VisionEntityIdsCache;
	}
}
