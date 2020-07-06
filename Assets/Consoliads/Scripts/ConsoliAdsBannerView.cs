using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoliAdsBannerView {

	private int bannerID; 
    private AdSize adSize;
    private AdPosition adPosition;
	private BannerType bannerType;


    public ConsoliAdsBannerView()
    {
		this.bannerID = this.GetHashCode ();
		this.bannerType = BannerType.PORTAL;
    }

    public ConsoliAdsBannerView(AdSize adSize)
    {
		this.adSize = adSize;
		this.bannerID = this.GetHashCode ();
		this.bannerType = BannerType.CUSTOM_SIZE;
    }

    public ConsoliAdsBannerView(AdPosition adPosition)
    {
        this.adPosition = adPosition;
		this.bannerID = this.GetHashCode ();
		this.bannerType = BannerType.CUSTOM_POSITION;
    }

    public ConsoliAdsBannerView(AdSize adSize , AdPosition adPosition)
    {
        this.adSize = adSize;
        this.adPosition = adPosition;
		this.bannerID = this.GetHashCode ();
		this.bannerType = BannerType.CUSTOM_SIZE_POSITION;
    }

	public int getBannerID()
	{
		return this.bannerID;
	}

	public AdSize getAdSize()
	{
		return this.adSize;
	}

	public AdPosition getAdPosition()
	{
		return this.adPosition;
	}

	public BannerType getBannerType()
	{
		return this.bannerType;
	}
}
