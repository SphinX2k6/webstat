using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Effect.Portal;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.SceneItem.Model
{
	// Token: 0x02004843 RID: 18499
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class PortalModel : ModelBase<PortalModel>
	{
		// Token: 0x06030216 RID: 197142 RVA: 0x00BAC839 File Offset: 0x00BAAA39
		protected override bool OnInit()
		{
			this.PortalCache = new Dictionary<long, BP_Portal_C>();
			return true;
		}

		// Token: 0x06030217 RID: 197143 RVA: 0x00BAC847 File Offset: 0x00BAAA47
		public void AddPortalPair(long portalId, BP_Portal_C portal)
		{
			if (this.PortalCache.ContainsKey(portalId))
			{
				return;
			}
			this.PortalCache[portalId] = portal;
		}

		// Token: 0x06030218 RID: 197144 RVA: 0x00BAC865 File Offset: 0x00BAAA65
		public void RemovePortalPair(long portalFixId)
		{
			this.PortalCache.Remove(portalFixId);
		}

		// Token: 0x06030219 RID: 197145 RVA: 0x00BAC874 File Offset: 0x00BAAA74
		[NullableContext(2)]
		public BP_Portal_C GetPortal(long portalId)
		{
			BP_Portal_C result;
			if (this.PortalCache.TryGetValue(portalId, out result))
			{
				return result;
			}
			return null;
		}

		// Token: 0x0603021A RID: 197146 RVA: 0x00BAC894 File Offset: 0x00BAAA94
		public IReadOnlyDictionary<long, BP_Portal_C> GetPortals()
		{
			return this.PortalCache;
		}

		// Token: 0x0603021B RID: 197147 RVA: 0x00BAC89C File Offset: 0x00BAAA9C
		protected override bool OnClear()
		{
			this.PortalCache = null;
			if (this.PortalInternal != null)
			{
				Singleton<ActorSystem>.Instance.Put("PortalModel.OnClear", this.PortalInternal, null);
				this.PortalInternal = null;
			}
			return true;
		}

		// Token: 0x0603021C RID: 197148 RVA: 0x00BAC8CC File Offset: 0x00BAAACC
		protected override bool OnLeaveLevel()
		{
			if (this.PortalInternal != null)
			{
				Singleton<ActorSystem>.Instance.Put("PortalModel.OnLeaveLevel", this.PortalInternal, null);
				this.PortalInternal = null;
			}
			return true;
		}

		// Token: 0x0603021D RID: 197149 RVA: 0x00BAC8F5 File Offset: 0x00BAAAF5
		public BP_Portal_C GetBpPortalActor()
		{
			if (this.PortalInternal == null)
			{
				this.PortalInternal = (Singleton<ActorSystem>.Instance.Spawn(BP_Portal_C.StaticClass(), new FTransformDouble(), null) as BP_Portal_C);
			}
			return this.PortalInternal;
		}

		// Token: 0x0401BA14 RID: 113172
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Dictionary<long, BP_Portal_C> PortalCache;

		// Token: 0x0401BA15 RID: 113173
		[Nullable(2)]
		private BP_Portal_C PortalInternal;
	}
}
